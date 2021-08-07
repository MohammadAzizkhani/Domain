using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;
using Domain.DbContext;
using Domain.Enums;
using Domain.Filters;
using Domain.Models;
using Domain.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Service.Interface;
using Service.ViewModel;

namespace Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly MMS_PortalContext _context;

        public CustomerService(MMS_PortalContext context)
        {
            _context = context;
        }

        public async Task AddPerson(Person model)
        {
            Person person = null;

            if (!string.IsNullOrEmpty(model.NationalNumber))
            {
                person = _context.People.FirstOrDefault(x => x.NationalNumber != null && x.NationalNumber == model.NationalNumber);
            }

            if (!string.IsNullOrEmpty(model.ForeignPervasiveCode))
            {
                person = _context.People.FirstOrDefault(x => x.ForeignPervasiveCode != null && x.ForeignPervasiveCode == model.ForeignPervasiveCode);
                model.NationalNumber = string.Empty;
            }

            if (!string.IsNullOrEmpty(model.NationalLegalCode) && !string.IsNullOrEmpty(model.NationalNumber))
            {
                person = _context.People.FirstOrDefault(x => x.NationalLegalCode != null && x.NationalLegalCode == model.RegisterNo);
            }

            var pspList = await GetActivePsps();
            var requests = pspList.Select(x => new Request
            {
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.MerchantRegister,
                TrackingNumber = Guid.NewGuid(),
                PspId = x.Id,
                RequestStateId = (byte)RequestStateEnum.SuccessRegistration
            }).ToList();

            if (person == null)
            {

                model.Customers.First().Requests = requests;
                await _context.People.AddAsync(model);
                await _context.SaveChangesAsync();
                return;
            }


            //var inputPostalCode = model.Customers.First().ShopPostalCode;
            //var inputGuildId = model.Customers.First().GuildId;
            //if (person.Customers.Any(x => x.ShopPostalCode == inputPostalCode && x.GuildId == inputGuildId))
            //{
            //    throw new MMSPortalException(CreateCustomerException.AlreadyExist.GetEnumDescription());
            //}

            var inputCustomer = model.Customers.First();
            inputCustomer.PersonId = person.Id;

            inputCustomer.Requests = requests;

            await _context.Customers.AddAsync(inputCustomer);

            await _context.SaveChangesAsync();

        }

        public async Task<PageCollection<Customer>> GetCustomers(CustomerFilter filter)
        {
            var query = _context.Customers.Include(x => x.Guild).Include(x => x.Merchants).Include(p => p.Person).AsQueryable();

            //var columnsMap = new Dictionary<string, Expression<Func<Customer, object>>>
            //{
            //    ["id"] = v => v.Id,
            //};

            //query = query.ApplyOrdering(filter, columnsMap);

            if (!string.IsNullOrEmpty(filter.NationalId))
            {
                query = query.Where(x => x.Person.NationalNumber == filter.NationalId);
            }
            if (!string.IsNullOrEmpty(filter.ShopName))
            {
                query = query.Where(x => x.ShopNameFa.Contains(filter.ShopName));
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Person.FirstNameFa.Contains(filter.Name) || x.Person.FirstNameFa.Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.LastName))
            {
                query = query.Where(x => x.Person.LastNameFa.Contains(filter.LastName) || x.Person.LastNameEn.Contains(filter.LastName));
            }
            if (!string.IsNullOrEmpty(filter.ForeignPervasiveCode))
            {
                query = query.Where(x => x.Person.ForeignPervasiveCode == filter.ForeignPervasiveCode);
            }
            if (!string.IsNullOrEmpty(filter.RegisterNo))
            {
                query = query.Where(x => x.Person.NationalLegalCode == filter.RegisterNo);
            }
            if (!string.IsNullOrEmpty(filter.CustomerId))
            {
                query = query.Where(x => x.CustomerKey == filter.CustomerId);
            }
            var count = await query.CountAsync();

            query = query.ApplyPaging(filter);

            var data = await query.ToListAsync();



            return new PageCollection<Customer>
            {
                Data = data,
                Pages = (int)Math.Ceiling((double)count / filter.PageSize),
                TotalRecord = count
            };

        }

        public async Task EditGuild(long customerId, int guildId)
        {
            var pspList = await GetActivePsps();

            var requests = pspList.Select(x => new Request
            {
                CustomerId = customerId,
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.ChangeGuild,
                TrackingNumber = Guid.NewGuid(),
                PspId = x.Id,
                RequestStateId = (byte)RequestStateEnum.SuccessRegistration,
                EditGuildRequests = new List<EditGuildRequest>
                {
                    new()
                    {
                        GuildId = guildId
                    }
                }
            }).ToList();

            await _context.Requests.AddRangeAsync(requests);

            await _context.SaveChangesAsync();

        }

        public async Task EditPostalCode(long customerId, string postalCode)
        {
            var pspList = await GetActivePsps();

            var requests = pspList.Select(x => new Request
            {
                CustomerId = customerId,
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.ChangePostalCode,
                TrackingNumber = Guid.NewGuid(),
                PspId = x.Id,
                RequestStateId = (byte)RequestStateEnum.SuccessRegistration,
                EditPostalCodeRequests = new List<EditPostalCodeRequest>
                {
                    new()
                    {
                        PostalCode = postalCode
                    }
                }
            }).ToList();

            await _context.Requests.AddRangeAsync(requests);

            await _context.SaveChangesAsync();
        }

        public async Task ActivateTerminals(long customerId)
        {
            var pspList = await GetActivePsps();

            var requests = pspList.Select(x => new Request
            {
                CustomerId = customerId,
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.TerminalActivation,
                TrackingNumber = Guid.NewGuid(),
                RequestStateId = (byte)RequestStateEnum.SuccessRegistration,
                PspId = x.Id
            }).ToList();

            await _context.Requests.AddRangeAsync(requests);

            await _context.SaveChangesAsync();
        }

        public async Task DeactivateTerminals(long customerId)
        {
            var pspList = await GetActivePsps();

            var requests = pspList.Select(x => new Request
            {
                CustomerId = customerId,
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.TerminalDeactivation,
                TrackingNumber = Guid.NewGuid(),
                PspId = x.Id,
                RequestStateId = (byte)RequestStateEnum.SuccessRegistration
            }).ToList();

            await _context.Requests.AddRangeAsync(requests);

            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomersIban>> GetCustomerIban(long customerId)
        {
            return await _context.CustomersIbans.Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task EditCustomerIbans(List<CustomersIban> ibans)
        {
            var pspList = await GetActivePsps();

            var customerId = ibans.FirstOrDefault()?.CustomerId;

            if (ibans.Count(i => i.IsMain != null && i.IsMain.Value) > 1)
            {
                throw new MMSPortalException(EditIbanRequestException.InvalidMainAccount.GetEnumDescription());
            }

            var requests = pspList.Select(x => new Request
            {
                CustomerId = customerId,
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.ChangeIban,
                TrackingNumber = Guid.NewGuid(),
                PspId = x.Id,
                RequestStateId = (byte)RequestStateEnum.SuccessRegistration,
                EditIbanRequests = ibans.Select(x => new EditIbanRequest
                {
                    Iban = x.Iban,
                    ShareType = x.ShareType ?? (byte)ShareTypeEnum.Amount,
                    AccountNumber = x.AccountNumber,
                    IsMain = x.IsMain ?? false,
                    ShareAmountMax = x.ShareAmountMax,
                    ShareAmountMin = x.ShareAmountMin,
                    SharedAmount = x.SharedAmount

                }).ToList()
            }).ToList();

            await _context.Requests.AddRangeAsync(requests);

            await _context.SaveChangesAsync();
        }


        public async Task<Customer> AddCustomer(Customer model)
        {
            var pspList = await GetActivePsps();

            model.Requests = pspList.Select(x => new Request
            {
                CustomerId = model.Id,
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.MerchantRegister,
                TrackingNumber = Guid.NewGuid(),
                PspId = x.Id
            }).ToList();

            await _context.Customers.AddAsync(model);

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task AddCustomerIbans(List<CustomersIban> ibans)
        {
            await _context.CustomersIbans.AddRangeAsync(ibans);

            var pspList = await GetActivePsps();

            var customerId = ibans.FirstOrDefault()?.CustomerId;

            var requests = pspList.Select(x => new Request
            {
                CustomerId = customerId,
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.MerchantRegister,
                TrackingNumber = Guid.NewGuid(),
                PspId = x.Id
            }).ToList();

            await _context.Requests.AddRangeAsync(requests);

            await _context.SaveChangesAsync();
        }

        private async Task<List<Psp>> GetActivePsps()
        {
            return await _context.Psps.Where(x => x.Enabled.HasValue && x.Enabled.Value).ToListAsync();
        }

        public async Task<PageCollection<Request>> GetRequests(RequestFilter filter)
        {
            var query = _context.Requests.Where(r => !r.IsDeleted).Include(c => c.Customer.Person).Include(r => r.Psp).AsQueryable();

            if (!string.IsNullOrEmpty(filter.NationalId))
            {
                query = query.Where(x => x.Customer.Person.NationalNumber == filter.NationalId);
            }
            if (!string.IsNullOrEmpty(filter.ForeignPervasiveCode))
            {
                query = query.Where(x => x.Customer.Person.ForeignPervasiveCode == filter.ForeignPervasiveCode);
            }
            if (!string.IsNullOrEmpty(filter.LegalNationalCode))
            {
                query = query.Where(x => x.Customer.Person.NationalLegalCode == filter.LegalNationalCode);
            }
            if (!string.IsNullOrEmpty(filter.ShopName))
            {
                query = query.Where(x => x.Customer.ShopNameFa.Contains(filter.ShopName));
            }
            if (filter.RequestStates.Any())
            {
                query = query.Where(x => filter.RequestStates.Contains(x.RequestStateId.Value));
            }
            if (filter.PspId.HasValue)
            {
                query = query.Where(x => x.PspId == filter.PspId.Value);
            }
            if (filter.RequestType.HasValue)
            {
                query = query.Where(x => x.RequestTypeId == (byte)filter.RequestType.Value);
            }
            if (!string.IsNullOrEmpty(filter.CustomerKey))
            {
                query = query.Where(x => x.Customer.CustomerKey == filter.CustomerKey);
            }

            var count = await query.CountAsync();

            query = query.ApplyPaging(filter);

            return new PageCollection<Request>
            {
                Data = await query.ToListAsync(),
                Pages = (int)Math.Ceiling((double)count / filter.PageSize),
                TotalRecord = count
            };
        }

        public async Task<Person> GetPerson(PersonType type, string uniqueIdentifier)
        {
            Person person = null;
            switch (type)
            {
                case PersonType.RealPerson:
                    person = await _context.People.FirstOrDefaultAsync(x => x.NationalNumber != null && x.NationalNumber == uniqueIdentifier);
                    break;
                case PersonType.LegalPerson:
                    person = await _context.People.FirstOrDefaultAsync(x =>
                        x.RegisterNo != null && x.NationalLegalCode == uniqueIdentifier);
                    break;
                case PersonType.Foreign:
                    person = await _context.People.FirstOrDefaultAsync(x =>
                        x.ForeignPervasiveCode != null && x.ForeignPervasiveCode == uniqueIdentifier);
                    break;
                default:
                    throw new MMSPortalException(GeneralException.NotFound.GetEnumDescription());
            }

            if (person == null)
                throw new MMSPortalException(GeneralException.NotFound.GetEnumDescription());
            return person;
        }

        public async Task StartEditRequest(long requestId, string userName)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(r => r.Id == requestId);

            if (request == null)
            {
                throw new MMSPortalException("Not Exist");
            }

            lock (request)
            {
                request.EditedBy = userName;
                _context.Requests.Update(request);
                _context.SaveChanges();
            }
        }

        public async Task EditRequest(EditRequestViewModel model, string username)
        {
            var request = await _context.Requests.Include(x => x.Customer.Person).Include(x => x.Customer.CustomersIbans).FirstOrDefaultAsync(r => r.Id == model.Id);

            if (request == null)
            {
                throw new MMSPortalException("Not Exist");
            }

            if (request.EditedBy != username)
            {
                throw new MMSPortalException("در حال ویرایش توسط کاربری دیگر است");
            }

            var requestHistory = new RequestHistory
            {
                RequestState = request.RequestStateId,
                TrackingNumber = request.TrackingNumber,
                InsertDateTime = request.InsertDateTime,
                ShaparakDescription = request.ShaparakDescription,
                ShaparakState = request.ShaparakState,
                ShaparakTrackingNumber = request.ShaparakTrackingNumber,
                RequestId = request.Id
            };
            await _context.RequestHistories.AddAsync(requestHistory);


            request.Customer.GuildId = model.GuildId;
            request.Customer.ShopPostalCode = model.ShopPostalCode;
            request.Customer.TaxPayerCode = model.TaxPayerCode;
            request.Customer.Person.FirstNameFa = model.FirstNameFa;
            request.Customer.Person.LastNameFa = model.LastNameFa;
            request.Customer.RedirectUrl = model.RedirectUrl;
            request.Customer.ShopCityPreCode = model.ShopCityPreCode;
            request.Customer.ShopTelephoneNumber = model.ShopTelephoneNumber;

            request.RequestStateId = GetRequestPrevioseState(request.RequestStateId);

            request.EditedBy = null;

            _context.Requests.Update(request);
            await _context.SaveChangesAsync();

        }

        public async Task RemoveRequest(long id)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(r => r.Id == id);

            if (request == null)
            {
                throw new MMSPortalException("Not Exist");
            }

            request.IsDeleted = true;
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task UploadFile(Document document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
        }

        public async Task<Document> DownloadFile(int id)
        {
            return await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<FileDto>> GetCustomerFiles(int customerId)
        {
            return await _context.Documents
                .Where(c => c.CustomerId == customerId)
                .Join(_context.DocTypes, d => d.DocTypeId, t => t.Id, (d, t) => new FileDto
                {
                    Id = d.Id,
                    InsertTime = d.InsertTime,
                    TypeName = t.TypeName,
                    ContentType = d.ContentType
                }).ToListAsync();
        }

        private byte GetRequestPrevioseState(byte? stateId)
        {
            switch (stateId)
            {
                case (byte)RequestStateEnum.PspPrimaryFailed:
                    return (byte)RequestStateEnum.SuccessRegistration;
                case (byte)RequestStateEnum.PspSecondaryFailed:
                    return (byte)RequestStateEnum.SuccessRegistration;
                case (byte)RequestStateEnum.PrimaryShparakFailed:
                    return (byte)RequestStateEnum.PspSecondaryAccepted;
                case (byte)RequestStateEnum.ShaparakTimeOutError:
                    return (byte)RequestStateEnum.PspSecondaryAccepted;
                case (byte)RequestStateEnum.ShaparakBadDataError:
                    return (byte)RequestStateEnum.PspSecondaryAccepted;
                case (byte)RequestStateEnum.SecondaryShparakFailed:
                    return (byte)RequestStateEnum.PspSecondaryAccepted;
                default:
                    return (byte)RequestStateEnum.SuccessRegistration;
            }
        }
    }
}

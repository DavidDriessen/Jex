using FastEndpoints;
using Jex.Application.Requests.Backoffice.Company;
using Jex.Application.Responses.Company;
using Jex.Persistence.Abstraction.Models;

namespace Jex.Application.Mappers;

public class UpdateCompanyMapper : Mapper<UpdateCompanyRequest, CompanyResponse, Company>
{
    public override Company ToEntity(UpdateCompanyRequest r) => new()
    {
        Id = r.CompanyId,
        Name = r.Name,
        Address = r.Address
    };

    public override CompanyResponse FromEntity(Company e) => new()
    {
        Id = e.Id,
        Name = e.Name,
        Address = e.Address
    };
}
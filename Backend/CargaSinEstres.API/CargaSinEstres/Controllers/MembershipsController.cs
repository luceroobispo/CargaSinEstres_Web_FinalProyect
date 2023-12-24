using AutoMapper;
using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Resources;
using CargaSinEstres.API.Security.Domain.Services;
using CargaSinEstres.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CargaSinEstres.API.CargaSinEstres.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class MembershipsController : ControllerBase
{
    private readonly IMembershipService _membershipService;
    private readonly IMapper _mapper;
    private readonly ICompanyService _companyService;

    //constructor
    public MembershipsController(IMembershipService membershipService, IMapper mapper, ICompanyService companyService)
    {
        _membershipService = membershipService;
        _mapper = mapper;
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<ActionResult<MembershipResource>> GetMemberships()
    {
        var membership = await _membershipService.GetMembershipsAsync();
        var membershipDto = _mapper.Map<IEnumerable<Membership>, IEnumerable<MembershipResource>>(membership);
        return Ok(membershipDto);
    }

    [HttpPost]
    public async Task<ActionResult> CreateMembership(SaveMembershipResource saveMembershipResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var membership = _mapper.Map<SaveMembershipResource, Membership>(saveMembershipResource);
        var membershipCreated = await _membershipService.SaveAsync(membership);
        var membershipDto = _mapper.Map<Membership, MembershipResource>(membershipCreated.Resource);
        return Ok(membershipDto);
    }
    
}
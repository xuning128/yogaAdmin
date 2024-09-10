using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Microsoft.EntityFrameworkCore;
using yogaAdminLib.Data;
using yogaAdminLib.DTOs;
using yogaAdminAPI.Interfaces;
using yogaAdminLib.Entities.yogaAdmin;
using AutoMapper;


namespace yogaAdminAPI.Services;


/// <summary>
/// 瑜珈老師 服務
/// </summary>
public class TeacherService : ITeacherService
{

    private ILogger<TeacherService> _logger;
    private readonly yogaAdminDataContext _yogaAdminDataContext;
    private readonly IMapper _mapper;

    public TeacherService(yogaAdminDataContext yogaAdminDataContext
        , IMapper mapper
        , ILogger<TeacherService> logger)
    {
        _yogaAdminDataContext = yogaAdminDataContext;
        _logger = logger;
        _mapper = mapper;

    }

    public async Task<QueryRs> GetQuery(QueryRq Rq)
    {
        QueryRs resp = new QueryRs();
        resp.TeacherLt = new List<TeacherItem>();

        try
        {
            resp.TeacherId = Rq.TeacherId;

            List<Teacher> query = new List<Teacher>();


            if (Rq.TeacherId == "all")
            {
                query = await _yogaAdminDataContext.Teachers.ToListAsync();
            }
            else
            {
                query = await _yogaAdminDataContext.Teachers.Where(x => x.id == Rq.TeacherId).ToListAsync();
            }

            if (query.Count() > 0)
            {
                resp.TeacherLt =  _mapper.Map<List<Teacher>, List<TeacherItem>>(query);
            }

        }
        catch (Exception ex)
        {
            //todo add nlog 

            string errMsg = ex.Message;

            throw;
        }

        return resp;
    }




}
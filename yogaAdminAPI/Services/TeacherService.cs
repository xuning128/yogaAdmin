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
using Microsoft.IdentityModel.Tokens;


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
                resp.TeacherLt = _mapper.Map<List<Teacher>, List<TeacherItem>>(query);
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


    /// <summary>
    /// 透過csv新增瑜珈老師的基本資料
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public async Task<AddRs> Add(IFormFile file)
    {
        AddRs resp = new AddRs();

        try
        {

            #region 內容轉Entity

            List<Teacher> req = await ContentToModel(file);

            if (req.Count() > 0)
            {
                foreach (var item in req)
                {
                    Teacher teacher = _mapper.Map<Teacher>(item);
                    await _yogaAdminDataContext.AddAsync(teacher);
                }

                await _yogaAdminDataContext.SaveChangesAsync();

                resp.StateCode = "0";
                resp.StateCodeDesc = "新增完成";
            }
            else
            {
                resp.StateCode = "0";
                resp.StateCodeDesc = "檔案無資料，未新增任何資料";
            }


            #endregion 內容轉Entity
        }
        catch (Exception ex)
        {

            string errMsg = ex.Message;
            //todo add nlog

            resp.StateCode = "555";
            resp.StateCodeDesc = "新增資料有誤";

            return resp;
        }

        return resp;

    }


    /// <summary>
    /// 檔案讀取
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    private async Task<List<Teacher>> ContentToModel(IFormFile file)
    {
        List<Teacher> teachers = new List<Teacher>();

        try
        {
            // Step 4: Read the content of the file (if needed)
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                //var content = await reader.ReadToEndAsync();

                

                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();

                    string[] values = line.Split(',');

                    Teacher item = new Teacher();
                    item.id = Guid.NewGuid().ToString();
                    item.name = values[0]; //老師中文名字
                    item.eng_name = values[1]; //老師英文名字
                    item.mobile = values[2]; //手機號碼
                    item.worktype = values[3]; //工作性質
                    item.isfulltime = item.worktype == "全職" ? true : false;
                    item.createtime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                    teachers.Add(item);

                }

            }
        }
        catch (Exception ex)
        {
            string errMsg = ex.Message;

            //todo add nlog

        }

        return teachers;
    }

}
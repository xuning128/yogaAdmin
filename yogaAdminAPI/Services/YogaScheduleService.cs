using yogaAdminLib.Data;
using yogaAdminAPI.Interfaces;
using AutoMapper;
using yogaAdminLib.DTOs.YogaSchedule;
using yogaAdminLib.Entities.yogaAdmin;
using Microsoft.EntityFrameworkCore;


namespace yogaAdminAPI.Services;


/// <summary>
/// 課表 Service
/// </summary>
public class YogaScheduleService : IYogaScheduleService
{

    private ILogger<YogaScheduleService> _logger;
    private readonly yogaAdminDataContext _yogaAdminDataContext;
    private readonly IMapper _mapper;

    public YogaScheduleService(yogaAdminDataContext yogaAdminDataContext
        , IMapper mapper
        , ILogger<YogaScheduleService> logger)
    {
        _yogaAdminDataContext = yogaAdminDataContext;
        _logger = logger;
        _mapper = mapper;

    }

    #region 新增課表

    /// <summary>
    /// 上傳csv檔 新增課表資訊
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public async Task<QueryRs> Insert(IFormFile file)
    {
        QueryRs rsObj = new QueryRs();
        rsObj.Schedules = new List<Schedule>();

        try
        {


            List<YogaSchedule> req = await ContentToModel(file);


            if (req.Count() > 0)
            {
                foreach (var item in req)
                {
                    YogaSchedule yogaSchedule = _mapper.Map<YogaSchedule>(item);
                    await _yogaAdminDataContext.AddAsync(yogaSchedule);

                    Schedule schedule = _mapper.Map<YogaSchedule, Schedule>(yogaSchedule);
                    string[] names = await GetTeacherName(schedule.TeacherId);
                    schedule.TeacherCName = names[0];
                    schedule.TeacherEName = names[1];
                    rsObj.Schedules.Add(schedule);
                }

                await _yogaAdminDataContext.SaveChangesAsync();




                rsObj.StateCode = "0";
                rsObj.StateCodeDesc = "新增完成";
            }
            else
            {
                rsObj.StateCode = "0";
                rsObj.StateCodeDesc = "檔案無資料，未新增任何資料";
            }



        }
        catch (Exception ex)
        {

            string errMsg = ex.Message;
            _logger.LogInformation($"新增課表有誤：{errMsg}");

            rsObj.StateCode = "999";
            rsObj.StateCodeDesc = "新增課表有誤";


        }

        return rsObj;

    }

    #endregion 新增課表


    #region  methods


    /// <summary>
    /// 檔案讀取
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    private async Task<List<YogaSchedule>> ContentToModel(IFormFile file)
    {
        List<YogaSchedule> yogaSchedules = new List<YogaSchedule>();

        try
        {
            //  Read the content of the file
            using (var reader = new StreamReader(file.OpenReadStream()))
            {

                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();

                    string[] values = line.Split(',');

                    YogaSchedule item = new YogaSchedule();
                    item.rquid = Guid.NewGuid().ToString();
                    item.classname = values[0]; //課程名字
                    item.classtime = values[1]; //課程時間
                    item.classweek = values[2]; //課程星期
                    string teachername = values[3];
                    item.teacherid = await GetTeacherId(teachername); //老師id
                    item.period = values[4]; //課程時間
                    item.classroom = values[5]; //教室資訊

                    item.issuspend = false; //預設停課 待闆娘自己打開
                    item.createtime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    item.modifytime = "";


                    if (!await isScheduleExsit(item.classweek, item.classtime, item.classroom))
                        yogaSchedules.Add(item);



                }

            }
        }
        catch (Exception ex)
        {
            string errMsg = ex.Message;

            //todo add nlog

        }

        return yogaSchedules;
    }


    /// <summary>
    /// 利用老師中文名字取得該老師的id
    /// </summary>
    /// <param name="teachername"></param>
    /// <returns></returns>
    private async Task<string> GetTeacherId(string teachername)
    {
        try
        {
            string teacherid = string.Empty;

            var req = await _yogaAdminDataContext.Teachers.Where(x => x.name == teachername).FirstOrDefaultAsync();

            teacherid = req != null ? req.id : "";

            return teacherid;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    /// <summary>
    /// 課程是否
    /// </summary>
    /// <param name="classweek"></param>
    /// <param name="classtime"></param>
    /// <param name="classroom"></param>
    /// <returns></returns>
    private async Task<bool> isScheduleExsit(string classweek, string classtime, string classroom)
    {
        try
        {
            bool isExsit = false;

            var req = await _yogaAdminDataContext.YogaSchedules
                                                .Where(x => x.classweek == classweek
                                                        && x.classtime == classtime
                                                        && x.classroom == classroom)
                                                .FirstOrDefaultAsync();

            isExsit = req != null ? true : false;

            return isExsit;
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    /// <summary>
    /// 取得教練名字
    /// </summary>
    /// <param name="teacherid"></param>
    /// <returns>
    /// [0] => 中文名字 <br/>
    /// [1] => 英文名字 
    /// </returns>
    private async Task<string[]> GetTeacherName(string teacherid)
    {
        try
        {
            string[] names = {"Cname", "Ename"};

            var req = await _yogaAdminDataContext.Teachers.Where(x=>x.id == teacherid).FirstAsync();

            names[0] = req.name;
            names[1] = req.eng_name;

            return names;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }



    #endregion 



}
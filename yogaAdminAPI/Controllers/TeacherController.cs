using Microsoft.AspNetCore.Mvc;
using yogaAdminAPI.Interfaces;
using yogaAdminLib.Data;
using yogaAdminLib.DTOs;

namespace yogaAdminAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{

    private readonly ILogger<TeacherController> _logger;

    private readonly yogaAdminDataContext _yogaAdminDataContext;
    private readonly ITeacherService _ITeacherService;
    public TeacherController(
        ITeacherService ITeacherService,
        yogaAdminDataContext yogaAdminDataContext,
        ILogger<TeacherController> logger)
    {
        yogaAdminDataContext = _yogaAdminDataContext;
        _ITeacherService = ITeacherService;
        _logger = logger;
    }

    /// <summary>
    /// 查詢瑜珈老師清單
    /// </summary>
    /// <param name="Rq"></param>
    /// <returns></returns>
    [HttpPost("Query")]
    public async Task<QueryRs> Query(QueryRq Rq)
    {

        try
        {
            QueryRs rsObj = new QueryRs();


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("TeacherId", "資料驗證錯誤");
                return rsObj;

            }

            rsObj = await _ITeacherService.GetQuery(Rq);

            return rsObj;

        }
        catch (Exception ex)
        {
            string errMsg = ex.Message;
            //TODO add nlog 
            throw;
        }

    }

    /// <summary>
    /// 新增瑜珈老師基本資料<br/>
    /// （檔案限制CSV檔）
    /// </summary>
    /// <param name="Rq"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<AddRs> Add(IFormFile file)
    {

        try
        {
            AddRs rsObj = new AddRs();


            if (file == null || file.Length == 0)
            {
                rsObj.StateCode = "999";
                rsObj.StateCodeDesc = "請上傳檔案";

                return rsObj;
            }

            // 確認是否為CSV檔案
            if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                rsObj.StateCode = "999";
                rsObj.StateCodeDesc = "只接受CSV檔案，請重新上傳";

                return rsObj;
            }

            rsObj = await _ITeacherService.Add(file);


            return rsObj;

        }
        catch (Exception ex)
        {
            string errMsg = ex.Message;
            //TODO add nlog 
            throw;
        }

    }


    /// <summary>
    /// 修改瑜珈老師清單
    /// </summary>
    /// <param name="Rq"></param>
    /// <returns></returns>
    [HttpPost("Edit")]
    public async Task<EditRs> Edit(EditRq rq)
    {

        try
        {
            EditRs rsObj = new EditRs();


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("TeacherId", "資料驗證錯誤");
                return rsObj;

            }

           rsObj = await _ITeacherService.Edit(rq);

            return rsObj;

        }
        catch (Exception ex)
        {
            string errMsg = ex.Message;
            //TODO add nlog 
            throw;
        }

    }


    /// <summary>
    /// 刪除瑜珈老師基本資料
    /// </summary>
    /// <param name="Rq"></param>
    /// <returns></returns>
    [HttpPost("Delete")]
    public async Task<EditRs> Delete(EditRq rq)
    {

        try
        {
            EditRs rsObj = new EditRs();


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("TeacherId", "資料驗證錯誤");
                return rsObj;

            }

           rsObj = await _ITeacherService.Edit(rq);

            return rsObj;

        }
        catch (Exception ex)
        {
            string errMsg = ex.Message;
            //TODO add nlog 
            throw;
        }

    }

}

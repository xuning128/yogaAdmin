
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using yogaAdminAPI.Controllers;
using yogaAdminAPI.Interfaces;
using yogaAdminLib.Data;
using Moq;
using yogaAdminLib.DTOs.Teacher;
using Microsoft.EntityFrameworkCore;
using yogaAdminLib.Entities.yogaAdmin;
using System.Text.Json;
using NLog;
using System.Net.Http.Json;
using System.Text;
using System.Net.Http.Headers;

namespace yogaAdmin.NUnitTests;
public class yogaAdminTests
{
    public const string APIUrl_Local = "https://localhost:7141/";

    public static NLog.Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();



    [TestCase("all")]
    public static async Task Query(string TeacherId)
    {
        string apiUrl = APIUrl_Local;

        try
        {

            QueryRq rqObj = new QueryRq();
            rqObj.TeacherId = TeacherId;
            using (var httpClientHandler = new HttpClientHandler())
            {
                //強制默認有通過SSL
                httpClientHandler.ServerCertificateCustomValidationCallback = delegate { return true; };

                using (var _httpClient = new HttpClient(httpClientHandler))
                {
                    _httpClient.Timeout = new TimeSpan(0, 0, 180);
                    _httpClient.DefaultRequestHeaders.Clear();
                    _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

                    string url = apiUrl + "Teacher/Query";
                    using JsonContent content = JsonContent.Create(rqObj);
                    using HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string respJson = response.Content.ReadAsStringAsync().Result;
                        var resp = JsonSerializer.Deserialize<QueryRs>(respJson);
                        _logger.Log(NLog.LogLevel.Info, respJson);
                    }
                    else
                    {
                        _logger.Log(NLog.LogLevel.Info, response);
                    }
                }
            }

        }
        catch (Exception ex)
        {

            string errMsg = ex.Message;

        }




    }



    [TestCase("/Users/aimefu/Desktop/作品集", "瑜珈老師D.csv")]
    public static async Task Add(string filepath, string filename)
    {
        string apiUrl = APIUrl_Local;

        try
        {


            using (var httpClientHandler = new HttpClientHandler())
            {
                //強制默認有通過SSL
                httpClientHandler.ServerCertificateCustomValidationCallback = delegate { return true; };

                using (var _httpClient = new HttpClient(httpClientHandler))
                {
                    _httpClient.Timeout = new TimeSpan(0, 0, 180);
                    _httpClient.DefaultRequestHeaders.Clear();
                    _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

                    string url = apiUrl + "Teacher/Add";

                    // Create the MultipartFormDataContent to handle the file upload and any additional data
                    using var formData = new MultipartFormDataContent();

                    string file = filepath + "/" + filename;

                    using var fileStream = File.OpenRead(file);
                    var fileContent = new StreamContent(fileStream);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

                    // Add the file to the form data, specifying the parameter name expected by the API (e.g., "file")
                    formData.Add(fileContent, "file", filename);

                    using HttpResponseMessage response = await _httpClient.PostAsync(url, formData);

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string respJson = response.Content.ReadAsStringAsync().Result;
                        var resp = JsonSerializer.Deserialize<AddRs>(respJson);
                        _logger.Log(NLog.LogLevel.Info, respJson);
                    }
                    else
                    {
                        _logger.Log(NLog.LogLevel.Info, response);
                    }
                }
            }

        }
        catch (Exception ex)
        {

            string errMsg = ex.Message;

        }




    }


    [TestCase("E", "4ac5c399-e478-4dfc-922a-27bc34a91d27", null, "Randy", null, null, null)]
    public static async Task Edit(string Action, string TeacherId, string TeacherCName, string TeacherEName
        , string Mobile, bool? IsFullTime, string WorkTypeDesc)
    {
        string apiUrl = APIUrl_Local;

        try
        {

            EditRq rqObj = new EditRq();
            rqObj.Action = Action;
            rqObj.TeacherId = TeacherId;
            rqObj.TeacherCName = TeacherCName;
            rqObj.TeacherEName = TeacherEName;
            rqObj.Mobile = Mobile;
            rqObj.IsFullTime = IsFullTime;
            rqObj.WorkTypeDesc = WorkTypeDesc;

            using (var httpClientHandler = new HttpClientHandler())
            {
                //強制默認有通過SSL
                httpClientHandler.ServerCertificateCustomValidationCallback = delegate { return true; };

                using (var _httpClient = new HttpClient(httpClientHandler))
                {
                    _httpClient.Timeout = new TimeSpan(0, 0, 180);
                    _httpClient.DefaultRequestHeaders.Clear();
                    _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

                    string url = apiUrl + "Teacher/Edit";
                    using JsonContent content = JsonContent.Create(rqObj);
                    using HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string respJson = response.Content.ReadAsStringAsync().Result;
                        var resp = JsonSerializer.Deserialize<EditRs>(respJson);
                        _logger.Log(NLog.LogLevel.Info, respJson);
                    }
                    else
                    {
                        _logger.Log(NLog.LogLevel.Info, response);
                    }
                }
            }

        }
        catch (Exception ex)
        {

            string errMsg = ex.Message;

        }




    }



    [TestCase("D", "8ebd234a-1108-4098-ba8c-120a34fc1b87", null, null, null, null, null)]
    public static async Task Delete(string Action, string TeacherId, string TeacherCName, string TeacherEName
      , string Mobile, bool? IsFullTime, string WorkTypeDesc)
    {
        string apiUrl = APIUrl_Local;

        try
        {

            EditRq rqObj = new EditRq();
            rqObj.Action = Action;
            rqObj.TeacherId = TeacherId;
            rqObj.TeacherCName = TeacherCName;
            rqObj.TeacherEName = TeacherEName;
            rqObj.Mobile = Mobile;
            rqObj.IsFullTime = IsFullTime;
            rqObj.WorkTypeDesc = WorkTypeDesc;

            using (var httpClientHandler = new HttpClientHandler())
            {
                //強制默認有通過SSL
                httpClientHandler.ServerCertificateCustomValidationCallback = delegate { return true; };

                using (var _httpClient = new HttpClient(httpClientHandler))
                {
                    _httpClient.Timeout = new TimeSpan(0, 0, 180);
                    _httpClient.DefaultRequestHeaders.Clear();
                    _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

                    string url = apiUrl + "Teacher/Delete";
                    using JsonContent content = JsonContent.Create(rqObj);
                    using HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string respJson = response.Content.ReadAsStringAsync().Result;
                        var resp = JsonSerializer.Deserialize<EditRs>(respJson);
                        _logger.Log(NLog.LogLevel.Info, respJson);
                    }
                    else
                    {
                        _logger.Log(NLog.LogLevel.Info, response);
                    }
                }
            }

        }
        catch (Exception ex)
        {

            string errMsg = ex.Message;

        }




    }



}


using Microsoft.Extensions.Logging;
using NUnit.Framework;
using yogaAdminAPI.Controllers;
using yogaAdminAPI.Interfaces;
using yogaAdminLib.Data;
using Moq;
using yogaAdminLib.DTOs;
using Microsoft.EntityFrameworkCore;
using yogaAdminLib.Entities.yogaAdmin;
using System.Text.Json;
using NLog;
using System.Net.Http.Json;

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



}

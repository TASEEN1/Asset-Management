using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models;
using System.Diagnostics.Metrics;

namespace PMS_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CuttingController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public CuttingController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompany()
        {
            var data =await _globalMaster.cuttingmanager.GetCompany();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetYear()
        {
            var data = await _globalMaster.cuttingmanager.GetYear();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetBuyer(int comID, int year)
        {
            var data = await _globalMaster.cuttingmanager.GetBuyer(comID, year);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetStyle(int comID, int buyerID)
        {
            var data = await _globalMaster.cuttingmanager.GetStyle(comID, buyerID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetStyleInfo(int buyerID, int styleID)
        {
            var data = await _globalMaster.cuttingmanager.GetStyleInfo(buyerID, styleID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCutMasterView(int styleID)
        {
            var data = await _globalMaster.cuttingmanager.GetCutMasterView(styleID);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCutMaster(CutMaster cut)
        {
            var data = await _globalMaster.cuttingmanager.SaveCutMaster(cut);
            return Ok(new { message = data });
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingYear(int comID)
        {
            var data = await _globalMaster.cuttingmanager.GetCuttingYear(comID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingStyle(int Year, int comID)
        {
            var data = await _globalMaster.cuttingmanager.GetCuttingStyle(Year,comID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingPO(int styleID)
        {
            var data = await _globalMaster.cuttingmanager.GetCuttingPO(styleID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingCountry(int styleID, string POID)
        {
            var data = await _globalMaster.cuttingmanager.GetCuttingCountry(styleID, POID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingCutNo(int styleID, string POID)
        {
            var data = await _globalMaster.cuttingmanager.GetCuttingCutNo(styleID, POID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingLayNo(int styleID, string POID)
        {
            var data = await _globalMaster.cuttingmanager.GetCuttingLayNo(styleID, POID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingSizeRatio(int styleID, string POID)
        {
            var data = await _globalMaster.cuttingmanager.GetCuttingSizeRatio(styleID, POID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingColor(int styleID, string POID)
        {
            var data = await _globalMaster.cuttingmanager.GetCuttingColor(styleID, POID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingFabricDetails(int styleID, string POID)
        {
            var data = await _globalMaster.cuttingmanager.GetCuttingFabricDetails(styleID, POID);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCutting(List<CuttingSave> cut)
        {
            var data = await _globalMaster.cuttingmanager.SaveCutting(cut);
            return Ok(new { message = data });
        }

        [HttpPost]
        public async Task<IActionResult> SaveCuttingLaySize(List<CuttingLaySize> CLS)
        {
            var data = await _globalMaster.cuttingmanager.SaveCuttingLaySize(CLS);
            return Ok(new { message = data });
        }


        [HttpGet]
        public async Task<IActionResult> ForApprovalCuttingView(int comID)
        {
            var data = await _globalMaster.cuttingmanager.ForApprovalCuttingView(comID);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> ForApprovalCutting(List<CutForApprove> app)
        {
            var data = await _globalMaster.cuttingmanager.ForApprovalCutting(app);
            return Ok(new { message = data });
        }

        [HttpGet]
        public async Task<IActionResult> ApprovalCuttingView(int comID)
        {
            var data = await _globalMaster.cuttingmanager.ApprovalCuttingView(comID);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> ApprovalCutting(List<CutForApprove> app)
        {
            var data = await _globalMaster.cuttingmanager.ApprovalCutting(app);
            return Ok(new { message = data });
        }

        [HttpDelete]
        public async Task<IActionResult> CancelCutting(List<CutForApprove> app)
        {
            var data = await _globalMaster.cuttingmanager.CancelCutting(app);
            return Ok(new { message = data });
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyUserWise(int comID)
        {
            var data = await _globalMaster.cuttingmanager.GetCompanyUserWise(comID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetLay(int styleID, string POID)
        {
            var data = await _globalMaster.cuttingmanager.GetLay(styleID, POID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingStyleReport(int comID, int buyerID)
        {
            var data = await _globalMaster.cuttingmanager.GetCuttingStyleReport(comID, buyerID);
            return Ok(data);
        }
    }
}

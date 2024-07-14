﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.OrderMgt;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PIController : ControllerBase
    {

        private readonly IGlobalMaster _globalMaster;

        public PIController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> GetGeneratePIAddView(int Customer, int Buyer, string created_By)
        {
            var data = await _globalMaster.piManager.GetGeneratePIAddView(Customer, Buyer,created_By);
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> GetPIAddView(int Customer, string style, int Ref_no)
        {
            var data = await _globalMaster.piManager.GetPIAddView(Customer, style, Ref_no);
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> GetPiApproval_checkedBy_View( string   Created_by)
        {
            var data = await _globalMaster.piManager.GetPiApproval_checkedBy_View(Created_by);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPiApproval_approvedBy_view(string Created_by)
        {
            var data = await _globalMaster.piManager.GetPiApproval_approvedBy_view(Created_by);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPiApproval_ForApprovalView(string Created_by)
        {
            var data = await _globalMaster.piManager.GetPiApproval_ForApprovalView(Created_by);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPIcustomer()
        {
            var data = await _globalMaster.piManager.GetPIcustomer();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPIstyle()
        {
            var data = await _globalMaster.piManager.GetPIstyle();
            return Ok(data);
        }


        [HttpDelete]
        public async Task<IActionResult> PIDelete(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.PIDelete(app);
            return Ok(new { message = data });

        }


        [HttpPut]
        public async Task<IActionResult> PIRevise(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.PIRevise(app);
            return Ok(new { message = data });

        }

        [HttpPost]
        public async Task<IActionResult> GeneratePIAdd(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.GeneratePIAdd(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> GeneratePI(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.GeneratePI(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> ApprovedByApprove(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.ApprovedByApprove(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> CheckedByApprove(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.CheckedByApprove(app);
            return Ok(new { message = data });

        }
    }
}

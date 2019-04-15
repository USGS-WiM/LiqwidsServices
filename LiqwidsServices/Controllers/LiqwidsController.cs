//------------------------------------------------------------------------------
//----- HttpController ---------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2019 WIM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   Handles resources through the HTTP uniform interface.
//
//discussion:   Controllers are objects which handle all interaction with resources. 
//              
//
// 

using Microsoft.AspNetCore.Mvc;
using System;
using LiqwidsAgent;
using System.Threading.Tasks;
using System.Collections.Generic;
using WIM.Resources;

namespace LiqwidsServices.Controllers
{
    [Route("[controller]")]
    public class LiqwidsController : WIM.Services.Controllers.ControllerBase
    {
        public ILiqwidsAgent agent { get; set; }
        public LiqwidsController(ILiqwidsAgent agent ) : base()
        {
            this.agent = agent;
        }
        #region METHODS
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            //returns list of available Navigations
            try
            {
                var result = agent.method();
                sm($"message from controller {result} completed.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        #endregion
        #region HELPER METHODS

        #endregion
    }
}

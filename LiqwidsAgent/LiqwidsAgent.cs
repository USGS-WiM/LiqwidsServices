//------------------------------------------------------------------------------
//----- ServiceAgent -------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2019 WIM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   The service agent is responsible for initiating the service call, 
//              capturing the data that's returned and forwarding the data back to 
//              the requestor.
//
//discussion:   
//
// 

using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using WIM.Resources;
using WIM.Security.Authentication.Basic;

namespace LiqwidsAgent
{
    public interface ILiqwidsAgent: IBasicUserAgent
    {
        String method();     
    }

    public class LiqwidsAgent : ILiqwidsAgent
    {
        #region Properties
        private readonly HttpContext _context;
        #endregion
        #region Constructor
        public LiqwidsAgent(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor.HttpContext;
        }
        #endregion
        #region Methods
        public string method() {
            sm("message from agent");
            return "Liqwids string";
        }
        public IBasicUser GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region HELPER METHODS        
        private void sm(string message, MessageType type = MessageType.info)
        {
            this.sm(new Message() { msg = message, type = type });
        }
        protected void sm(Message msg)
        {
            //wim_msgs comes from WIM.Standard/blob/staging/Services/Middleware/X-Messages.cs
            //manually added to avoid including libr in project.
            if (!this._context.Items.ContainsKey("wim_msgs"))
                this._context.Items["wim_msgs"] = new List<Message>();

            ((List<Message>)this._context.Items["wim_msgs"]).Add(msg);
        }

    

        #endregion
    }

}
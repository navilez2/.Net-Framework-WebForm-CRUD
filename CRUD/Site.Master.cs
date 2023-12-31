﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace CRUD
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ShowMessageOnTop(string message,string type)
        {
            string script = "const alertPlaceholder = document.getElementById('messageContainer')\r\n" +
                            "const wrapper = document.createElement('div')\r\n" +
                            "wrapper.innerHTML = [\r\n " +
                            "           '<div style=\"position: fixed;z-index: 500;width: 100%;\" role=\"alert\">',\r\n " +
                            "              `<div style = \"rgba(144, 238, 144, 0.5)\" class=\"alert alert-" + type + " alert-dismissible\">`,\r\n   " +
                            "                `   <div>"+ message + "</div>`,\r\n  " +
                            "                '   <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>',\r\n  " +
                            "             '</div>',\r\n " +
                            "           '</div>'\r\n  " +
                            "].join('')\r\n\r\n" +
                            "const alertList = Array.from(alertPlaceholder.childNodes);\r\n" +
                            "      alertList.forEach((alert) => {\r\n  " +
                            "          alertPlaceholder.removeChild(alert);\r\n " +
                            "       })\r\n\r\n       " +
                            "alertPlaceholder.append(wrapper);";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowMessageScript", script, true);
        }

        public void Alert(string message)
        {
            string script = string.Format("alert('{0}');",message);
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlertScript", script, true);
        }
        public void AlertModal(string title, string message)
        {
            string script = "var container = document.createElement('div')\r\n" +
                            "container.innerHTML = [   " +
                            "      '<div class=\"modal fade\" id=\"modal\" tabindex=\"-1\" aria-labelledby=\"modalLabel\" aria-hidden=\"true\">',\r\n" +
                            "        '<div class=\"modal-dialog\">',\r\n " +
                            "            '<div class=\"modal-content\">',\r\n    " +
                            "               '<div class=\"modal-header\">',\r\n  " +
                            "                   '<h1 class=\"modal-title fs-5\" id=\"modalLabel\">"+ title + "</h1>',\r\n" +
                            "               '</div>',\r\n " +
                            "               '<div class=\"modal-body\">',\r\n " +
                            "                   '<form>',\r\n " +
                            "                   '<div style=\"display: flex;\">',\r\n   " +
                            "                       '<img style=\"height: 150px; width: 150px;\" src=\"../images/Caution.png\"/>',\r\n " +
                            "                       '<textarea class=\"form-control\" readonly id=\"message-text\">"+ message + "</textarea>',\r\n" +
                            "                   '</div>',\r\n " +
                            "                   '</form>',\r\n" +
                            "               '</div>',\r\n" +
                            "           '</div>',\r\n " +
                            "       '</div>',\r\n " +
                            "     '</div>'," +
                            "].join('');\r\n" +
                            "document.body.append(container);\r\n" +
                            "$('#modal').modal('show');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowErrorModal", script, true);
        }
    }
}
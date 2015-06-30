# How to convert ASP.NET user controls to JSON #

### The problem ###
So, you've implemented your ASP.NET website with pages and user controls.  Next, you're implementing some ajax callbacks to dynamically update some information on your page.  But the info you want to update has a bunch of styling around it, and all the presentation logic is already wrapped up in a user control.

### What to do? ###
Of course you can return a big chunk of HTML and just swap it out on the page.  But what if you're returning multiple pieces of information, that go in different places of the page, i.e. not in a nice html-sequential order?  How do you keep from repeating code while also being efficient?

You _could_ execute sequential ajax callbacks to get your formatted info piece by piece, but that's slow. If you could return all the pieces back as JSON, you could work with the presentation chunks more efficiently.  So, **how do we get user controls to return in json format?**

### A solution ###
Override the System.Web.UI.UserControl Render method on a user control to return the entire rendered control as a JSON string.

By capturing the rendered output of a UserControl (or an ASPX Page, for that matter), we can convert the html to a JSON-compliant string.  This allows us to re-use our complex and impressive presentation and formatting logic (;-) for AJAX updates.

Check out the example below.  The key components here:
  1. "Browser" web page (.aspx) that returns standard HTML (usually called by the browser as part of site navigation) with javascript on the page that executes ajax request and ensuing html dom update
  1. "Ajax" web page (.aspx) that receives the ajax callback request (usually called by ajax requests, returns data in json format)
  1. User control(s) that live on both the browser-based and ajax-based web pages

To facilitate the output to JSON, I added a public bool property "WriteAsJSON" to the user control, which is defaulted to false.  The control resides on both the BrowserPage.aspx as well as AjaxPage.aspx.  The default assignment is used on BrowserPage; AjaxPage assigns the WriteAsJSON property to true.

I also included the prototype.js and scriptaculous.js libraries because they reduce my need to write javascript.  There are lots of libraries like these around; I'm partial to these two.  Please see [http://www.prototypejs.org/](http://www.prototypejs.org/) and [http://script.aculo.us/](http://script.aculo.us/).

This example code can be **[downloaded](http://jsonsharp.googlecode.com/files/ASPdotNETControlsAsJSON.zip)** from our **[downloads page](http://code.google.com/p/jsonsharp/downloads/list)**. Of course, you'll need the JSONSharp library as well.


# An example #

### BrowserPage.aspx ###
```
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrowserPage.aspx.cs" Inherits="BrowserPage" Title="Untitled Page" %>
<%@ Register TagName="DualControl" TagPrefix="my" Src="~/DualControl.ascx" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>BrowserPage</title>
<script language="javascript" type="text/javascript" src="prototype.js"></script>
<script language="javascript" type="text/javascript" src="scriptaculous.js"></script>
<script language="javascript" type="text/javascript">
function changeContent() {
  var divcontent = $("content_div");
  divcontent.innerHTML="";
  new Ajax.Request('/AjaxPage.aspx', {method:'get', onSuccess:changeFunc});
}

function changeFunc(t) {
  var ajax_content = eval('('+t.responseText+')');
  var divcontent = $("content_div");
  pausecomp(1000);
  divcontent.innerHTML=ajax_content.dual_control;
}

// http://www.sean.co.uk/a/webdesign/javascriptdelay.shtm
function pausecomp(millis) {
  var date = new Date();
  var curDate = null;
  do { curDate = new Date(); }
  while(curDate-date < millis);
}

</script>
</head>
<body>
    <h1>Welcome to BrowserPage</h1>
    <p>The BrowserPage is (normally) loaded from a browser.</p>
    <p>The content below can be <a href="javascript:changeContent();">updated</a>.</p>
    <div id="content_div">
        <my:DualControl runat="server" ID="DualControl1" visible="true"/>
    </div>
</body>
</html>
```

### BrowserPage.aspx.cs ###
```
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class BrowserPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DataBind();
    }
}
```

### AjaxPage.aspx ###
```
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxPage.aspx.cs" Inherits="AjaxPage" %>
<%@ Register TagName="DualControl" TagPrefix="my" Src="~/DualControl.ascx" %>
{
"dual_control":
<my:DualControl WriteAsJSON="true" runat="server" ID="DualControl1" visible="true"/>
}
```


### AjaxPage.aspx.cs ###
```
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class AjaxPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DataBind();
    }
}
```


### DualControl.ascx ###
```
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DualControl.ascx.cs" Inherits="DualControl" %>
<asp:Repeater ID="rptrULOfProgressiveTime" runat="server">
  <HeaderTemplate>
    <h2>Progressive time-list</h2>
    <p>This list starts with the current time, then adds 10 seconds to each entry.</p>
    <ul>
  </HeaderTemplate>
  <ItemTemplate>
      <li><%# Convert.ToString(Container.DataItem) %></li>
  </ItemTemplate>
  <FooterTemplate>
    </ul>
  </FooterTemplate>
</asp:Repeater>
```


### DualControl.ascx.cs ###
```
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JSONSharp;

public partial class DualControl : System.Web.UI.UserControl
{
    public bool WriteAsJSON = false;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnDataBinding(EventArgs e)
    {
        List<DateTime> dtList = new List<DateTime>();
        for (int x = 1; x <= 5; x++)
        {
            dtList.Add(DateTime.Now.AddSeconds((x - 1) * 10));
        }
        this.rptrULOfProgressiveTime.DataSource = dtList;
        base.OnDataBinding(e);
    }

    protected override void Render(HtmlTextWriter writer)
    {
        if (this.WriteAsJSON)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.TextWriter tw = new System.IO.StringWriter(sb);
            HtmlTextWriter htwJson = new HtmlTextWriter(tw);
            base.Render(htwJson);
            writer.Write(JSONStringValue.ToJSONString(sb.ToString()));
        }
        else
        {
            base.Render(writer);
        }
    }
}
```
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageUpload.aspx.cs" Inherits="Stoke.USL.Staff.ImageUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
<head>
    <title>Aspect Ratio with Preview Pane | Jcrop Demo</title>
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />

    <script src="../../js/jquery.min.js"></script>

    <script src="../../js/jquery.Jcrop.js"></script>

    <script type="text/javascript">

  jQuery(function($){

    // Create variables (in this scope) to hold the API and image size
    var jcrop_api,
        boundx,
        boundy,

        // Grab some information about the preview pane
        $preview = $('#preview-pane'),
        $pcnt = $('#preview-pane .preview-container'),
        $pimg = $('#preview-pane .preview-container img'),

        xsize = $pcnt.width(),
        ysize = $pcnt.height();

    //console.log('init',[xsize,ysize]);

    $('#target').Jcrop({
      onChange: updatePreview,
      onSelect: updatePreview,
      aspectRatio: 1
    },function(){
      // Use the API to get the real image size
      var bounds = this.getBounds();
      boundx = bounds[0];
      boundy = bounds[1];
      // Store the API in the jcrop_api variable
      jcrop_api = this;

      // Move the preview into the jcrop container for css positioning
      $preview.appendTo(jcrop_api.ui.holder);
    });

    function updatePreview(c)
    {
      if (parseInt(c.w) > 0)
      {

        var rx = xsize / c.w;
        var ry = ysize / c.h;

        $pimg.css({
          width: Math.round(rx * boundx) + 'px',
          height: Math.round(ry * boundy) + 'px',
          marginLeft: '-' + Math.round(rx * c.x) + 'px',
          marginTop: '-' + Math.round(ry * c.y) + 'px'
        });
      }
      $('#<%= x1.ClientID %>').val(c.x);
      $('#<%= y1.ClientID %>').val(c.y);
      $('#<%= x2.ClientID %>').val(c.x2);
      $('#<%= y2.ClientID %>').val(c.y2);
      $('#<%= Iwidth.ClientID %>').val(c.w);
      $('#<%= Iheight.ClientID %>').val(c.h);
    };

  });


</script>

    <link rel="stylesheet" href="../../css/main.css" type="text/css" />
    <link rel="stylesheet" href="../../css/pic.css" type="text/css" />
    <link rel="stylesheet" href="../../css/jquery.Jcrop.css" type="text/css" />
    <style type="text/css">

/* Apply these styles only when #preview-pane has
   been placed within the Jcrop widget */
.jcrop-holder #preview-pane {
  display: block;
  position: absolute;
  z-index: 2000;
  top: 10px;
  right: -230px;
  padding: 6px;
  border: 1px rgba(0,0,0,.4) solid;
  background-color: white;

  -webkit-border-radius: 6px;
  -moz-border-radius: 6px;
  border-radius: 6px;

  -webkit-box-shadow: 1px 1px 5px 2px rgba(0, 0, 0, 0.2);
  -moz-box-shadow: 1px 1px 5px 2px rgba(0, 0, 0, 0.2);
  box-shadow: 1px 1px 5px 2px rgba(0, 0, 0, 0.2);
}

/* The Javascript code will set the aspect ratio of the crop
   area based on the size of the thumbnail preview,
   specified here */
#preview-pane .preview-container {
  width: 200px;
  height: 200px;
  overflow: hidden;
}

</style>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="span12">
                    <div class="jc-demo-box">
                        <div class="page-header">
                            <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;<asp:Button ID="Button1"
                                runat="server" Text="上传" OnClick="Button1_Click" />
                        </div>
                        <img src="<%= ImageUrl %>" id="target" alt="[Jcrop Example]" height="400px" />
                        <div id="preview-pane">
                            <div class="preview-container">
                                <img src="<%= ImageUrl %>" class="jcrop-preview" alt="Preview" />
                            </div>
                        </div>
                        <div class="clearfix">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="text-align: center;">
            <asp:Button runat="server" ID="uploadBtn" Text="确定" OnClick="uploadBtn_Click" /></div>
        <div style="display: none;">
            <asp:TextBox ID="x1" runat="server"></asp:TextBox>
            <asp:TextBox ID="y1" runat="server"></asp:TextBox>
            <asp:TextBox ID="x2" runat="server"></asp:TextBox>
            <asp:TextBox ID="y2" runat="server"></asp:TextBox>
            <asp:TextBox ID="Iwidth" runat="server"></asp:TextBox>
            <asp:TextBox ID="Iheight" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>

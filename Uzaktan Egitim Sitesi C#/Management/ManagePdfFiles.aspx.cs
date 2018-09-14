using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; // "File.Exists" için eklendi.

public partial class Management_ManagePdfFiles : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SqlDataSource1_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {
        DropDownList başlıkDropDownList = (DropDownList)Panel1.FindControl("DropDownList1");
        int anaBaşlıkId = Convert.ToInt32(başlıkDropDownList.SelectedValue);
        string başlıkİsmi = Convert.ToString(başlıkDropDownList.SelectedItem);

        FileUpload pdfFileUpload = (FileUpload)DetailsView1.FindControl("pdfFileUpload");
        string virtualFolder = "~/PdfFiles/" + başlıkİsmi + "/";
        string physicalFolder = Server.MapPath(virtualFolder);
        string fileName = Guid.NewGuid().ToString();
        string extension = System.IO.Path.GetExtension(pdfFileUpload.FileName);
        pdfFileUpload.SaveAs(System.IO.Path.Combine(physicalFolder, fileName + extension));

        // "FileUrl" InsertParametresi buradan gönderiliyor.
        e.Command.Parameters["@FileUrl"].Value = virtualFolder + fileName + extension;
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int pdfId = Convert.ToInt32(e.Keys["Id"]);

        using (MyWebSiteDatabaseEntities myEntity = new MyWebSiteDatabaseEntities())
        {
            var aramaSonucu = from pdf in myEntity.PdfFiles
                              where pdf.Id == pdfId
                              select pdf;

            if (aramaSonucu != null)
            {
                DropDownList başlıkDropDownList = (DropDownList)Panel1.FindControl("DropDownList1");
                string başlıkİsmi = Convert.ToString(başlıkDropDownList.SelectedItem);
                string virtualFolder = "~/PdfFiles/" + başlıkİsmi + "/";
                string physicalFolder = Server.MapPath(virtualFolder);

                PdfFile pdfFile = aramaSonucu.ToList().ElementAt(0);
                // "FileUrl"in başındaki "~/" siliniyor.
                string fileUrl = pdfFile.FileUrl.Substring(2);
                // Sitenin "root"u, "fileurl"a ekleniyor.
                // MapPath'e "~/" eklenmezse "currentServer" olarak "Management" klasörünü alıyor.
                string fullPath = Server.MapPath("~/" + fileUrl);

                // Pdf dosyası bulunursa siliniyor.
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }
    }
}
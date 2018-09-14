﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class AnaBasliklar
{
    public AnaBasliklar()
    {
        this.PdfFiles = new HashSet<PdfFile>();
        this.VideoUrls = new HashSet<VideoUrl>();
    }

    public int Id { get; set; }
    public string Baslik { get; set; }

    public virtual ICollection<PdfFile> PdfFiles { get; set; }
    public virtual ICollection<VideoUrl> VideoUrls { get; set; }
}

public partial class PdfFile
{
    public PdfFile()
    {
        this.PdfYorumları = new HashSet<PdfYorumları>();
    }

    public int Id { get; set; }
    public int AnaBaslikId { get; set; }
    public string FileUrl { get; set; }
    public string KonuBasliği { get; set; }

    public virtual AnaBasliklar AnaBasliklar { get; set; }
    public virtual ICollection<PdfYorumları> PdfYorumları { get; set; }
}

public partial class PdfYorumları
{
    public int Id { get; set; }
    public int PdfId { get; set; }
    public string UserName { get; set; }
    public string Yorum { get; set; }
    public string Tarih { get; set; }

    public virtual PdfFile PdfFile { get; set; }
}

public partial class VideoUrl
{
    public VideoUrl()
    {
        this.VideoYorumlaris = new HashSet<VideoYorumlari>();
    }

    public int Id { get; set; }
    public int AnaBaslikId { get; set; }
    public string VideoLink { get; set; }
    public string VideoBasliği { get; set; }

    public virtual AnaBasliklar AnaBasliklar { get; set; }
    public virtual ICollection<VideoYorumlari> VideoYorumlaris { get; set; }
}

public partial class VideoYorumlari
{
    public int Id { get; set; }
    public int VideoId { get; set; }
    public string UserName { get; set; }
    public string Yorum { get; set; }
    public string Tarih { get; set; }

    public virtual VideoUrl VideoUrl { get; set; }
}
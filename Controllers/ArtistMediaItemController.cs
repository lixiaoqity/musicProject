using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Win32;

namespace Assignment6.Controllers
{
    [Authorize]
    public class ArtistMediaItemController : Controller
    {
        Manager m = new Manager();

        // GET: ArtistMediaItem
        public ActionResult Index()
        {
            return View("index", "home");
        }

        // GET: ArtistMediaItem/5
        [Route("artistMediaItem/{stringId}")]
        public ActionResult Details(string stringId = "")
        {
            var o = m.ArtistMediaItemGetById(stringId);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(o.Content, o.ContentType);
            }
        }

        // GET: ArtistMediaItem/5/Download
        [Route("artistMediaItem/{stringId}/download")]
        public ActionResult DetailsDownload(string stringId = "")
        {
            // Attempt to get the matching object
            var o = m.ArtistMediaItemGetById(stringId);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Get file extension, assumes the web server is Microsoft IIS based
                // Must get the extension from the Registry (which is a key-value storage structure for configuration settings, for the Windows operating system and apps that opt to use the Registry)

                // Working variables
                string extension;
                RegistryKey key;
                object value;

                // Open the Registry, attempt to locate the key
                key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + o.ContentType, false);
                // Attempt to read the value of the key
                value = (key == null) ? null : key.GetValue("Extension", null);
                // Build/create the file extension string
                extension = (value == null) ? string.Empty : value.ToString();

                var fileName = "none";
                if (o.ContentType.Contains("image/"))
                    fileName = "img-";
                else if (o.ContentType.Contains("audio/"))
                    fileName = "audio-";
                else if (o.ContentType.Contains("word"))
                    fileName = "msword-";
                else if (o.ContentType.Contains("pdf"))
                    fileName = "pdf-";
                else if (o.ContentType.Contains("excel"))
                    fileName = "excel-";
                
                // Create a new Content-Disposition header
                var cd = new System.Net.Mime.ContentDisposition
                {
                    // Assemble the file name + extension
                    FileName = $"{fileName}{stringId}{extension}",
                    // Force the media item to be saved (not viewed)
                    Inline = false
                };
                // Add the header to the response
                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(o.Content, o.ContentType);
            }
        }
    }
}

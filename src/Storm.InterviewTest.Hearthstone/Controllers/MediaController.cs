using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class MediaController : Controller
    {
	    private const string mediaSourceUrl = "http://wow.zamimg.com/images/hearthstone/cards/enus/medium/{0}.png";

        private readonly IHostingEnvironment _hostingEnvironment;

        public MediaController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Media
        public ActionResult Card(string id)
        {
	        var cardFilename = string.Format("{0}.png", id);
	        var localBaseDirectory = Path.Combine(_hostingEnvironment.WebRootPath, "images\\cards");
	        Directory.CreateDirectory(localBaseDirectory);
	        var localFile = Path.Combine(localBaseDirectory, cardFilename);
	        if (!System.IO.File.Exists(localFile))
	        {
		        DownloadFromSource(id, localFile);
	        }

			return File(string.Format("~/images/cards/{0}", cardFilename), "image/png");
		}

	    private void DownloadFromSource(string cardId, string localFile) {
		    var client = new HttpClient();
            var data = client.GetByteArrayAsync(string.Format(mediaSourceUrl, cardId)).Result;

            System.IO.File.WriteAllBytes(localFile, data);
            
	    }
    }
}
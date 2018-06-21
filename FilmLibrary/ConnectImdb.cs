using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary
{
  class ConnectImdb
  {
    public static string retrieveRatingValue()
    {
      string ratingValue = "";
      //Shrek link 
      Uri uri = new Uri("http://www.imdb.com/title/tt0892791/");
      WebClient site = new WebClient();
      //Html from page
      string html = site.DownloadString(uri);
      //Title html tags
      string ratingValueTag = "<span itemprop=\"ratingValue\">";
      int indexA = html.IndexOf(ratingValueTag);

      //Found the tages
      if (indexA != -1)
      {

        int indexB = html.IndexOf("</span>", indexA);

        //Found second tages
        if (indexB != -1)
        {
          //index of will get the start of the search, we want the end
          indexA = indexA + ratingValueTag.Length;
          //Title is inbetween range
          ratingValue = html.Substring(indexA, indexB - indexA);
        }
      }

      return ratingValue;
    }
  }
}

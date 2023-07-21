using NSubstitute;
using PhotoAlbumShowcase.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PhotoAlbumShowcaseTests.Photos
{
    public class WebPhotoServiceTests
    {
        [Fact]
        public void Constructor_GivenIHttpFactory_CallsCreateClientWithPhotosName()
        {
            IHttpClientFactory factory = Substitute.For<IHttpClientFactory>();

            WebPhotoService webPhotoService = new WebPhotoService(factory);

            factory.Received(1).CreateClient("Photos");
        }
    }
}

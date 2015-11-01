using Sorting.SnakeCase.Utilities;
using Xunit;

namespace Sorting.SnakeCase.Test.Utilities
{
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData("url_value", "urlValue")]
        [InlineData("url_value", "UrlValue")]
        [InlineData("urlvalue", "URLVALUE")]
        [InlineData("url_value", "url_value")]
        [InlineData("url_value", "URL_VALUE")]
        [InlineData("url_exception", "URLException")]
        [InlineData("vpn_public_ip", "VPNPublicIP")]
        [InlineData("vpn_ip_addr", "VPNIpAddr")]
        [InlineData("id", "ID")]
        [InlineData("id", "Id")]
        [InlineData("i", "i")]
        [InlineData("i", "I")]
        [InlineData("i_phone", "iPhone")]
        [InlineData("i_phone", "IPhone")]
        [InlineData("i_phone_device_token_id", "IPhoneDeviceTokenID")]
        [InlineData("i_phone_device_rpc_token_id_for_url_friendly_sub", "IPhoneDeviceRPCTokenIDForURLFriendlySUB")]
        [InlineData("get_nfc_player", "GetNFCPlayer")]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData(null, null)]
        public void ToSnakeCase_Success(string expectedResult, string value)
        {
            Assert.Equal(expectedResult, value.ToSnakeCase());
        }
    }
}

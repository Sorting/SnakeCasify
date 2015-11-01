using Newtonsoft.Json;
using Sorting.SnakeCase.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Dynamic;
using Xunit;

namespace Sorting.SnakeCase.Test.Json.Serialization
{
    public class SnakeCasePropertyNamesContractResolverTest
    {

        [Fact]
        public void JsonConvertSerializer_SerializeTest()
        {
            // Arrange
            var person = new Person
            {
                BirthDay = new DateTime(2013, 09, 02, 06, 45, 43),
                LastModified = new DateTime(2013, 10, 21, 18, 23, 12),
                Name = "Name!"
            };

            // Act
            var json = JsonConvert.SerializeObject(person, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new SnakeCasePropertyNamesContractResolver()
            });

            // Assert
            Assert.Equal(@"{
  ""name"": ""Name!"",
  ""birth_day"": ""2013-09-02T06:45:43"",
  ""last_modified"": ""2013-10-21T18:23:12""
}", json);
        }


        [Fact]
        public void JsonConvertSerializer_DeserializeTest()
        {
            // Arrange
            var person = new Person
            {
                BirthDay = new DateTime(2013, 09, 02, 06, 45, 43),
                LastModified = new DateTime(2013, 10, 21, 18, 23, 12),
                Name = "Name!"
            };

            var json = @"{
  ""name"": ""Name!"",
  ""birth_day"": ""2013-09-02T06:45:43"",
  ""last_modified"": ""2013-10-21T18:23:12""
}";

            // Act
            var deserializedPerson = JsonConvert.DeserializeObject<Person>(json, new JsonSerializerSettings
            {
                ContractResolver = new SnakeCasePropertyNamesContractResolver()
            });

            // Assert
            Assert.Equal(person.Name, deserializedPerson.Name);
            Assert.Equal(person.BirthDay, deserializedPerson.BirthDay);
            Assert.Equal(person.LastModified, deserializedPerson.LastModified);
        }

        [Fact]
        public void SnakeCaseContractResolver_DictionarySerializingTest()
        {
            //Arrange
            var values = new Dictionary<string, string>
            {
                { "FirstValue", "Value1!" },
                { "SecondValue", "Value2!" }
            };

            //Act
            var json = JsonConvert.SerializeObject(values, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new SnakeCasePropertyNamesContractResolver()
            });

            //Assert
            Assert.Equal(@"{
  ""first_value"": ""Value1!"",
  ""second_value"": ""Value2!""
}", json);
        }

        [Fact]
        public void SnakeCaseContractResolver_DynamicObjectSerializerTest()
        {
            //Arrange
            dynamic o = new ExpandoObject();

            o.TextValue = "Text";
            o.IntValue = 100;
            o.EANStringID = "ID";
            o.DoubleValue = 1.0m;

            //Act
            var json = JsonConvert.SerializeObject(o, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new SnakeCasePropertyNamesContractResolver()
            });

            //Assert
            Assert.Equal(@"{
  ""text_value"": ""Text"",
  ""int_value"": 100,
  ""ean_string_id"": ""ID"",
  ""double_value"": 1.0
}", json);
        }

        [Fact]
        public void SnakeCaseContractResolver_AnonymouseObjectSerializerTest()
        {
            //Arrange
            var o = new
            {
                TextValue = "Text",
                IntValue = 100,
                EANStringID = "ID",
                DoubleValue = 1.0m
            };

            //Act
            var json = JsonConvert.SerializeObject(o, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new SnakeCasePropertyNamesContractResolver()
            });

            //Assert
            Assert.Equal(@"{
  ""text_value"": ""Text"",
  ""int_value"": 100,
  ""ean_string_id"": ""ID"",
  ""double_value"": 1.0
}", json);
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public DateTime LastModified { get; set; }
    }
}
<Query Kind="Statements">
  <Connection>
    <ID>856cf0d4-2ba0-43a7-bfef-583a4c06dcf4</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.Oracle</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAFd2CtC0ewkCGSAJ5Lejs3AAAAAACAAAAAAADZgAAwAAAABAAAACpgWrXKDddQ9c9VLGGPRqaAAAAAASAAACgAAAAEAAAAL8Bu5hbhtMsqtrSZ1WohA5AAAAAPYJBCleWUQ+XXHsnm67rVk4B9rUhfft8Mwn3nnvh8WpYY8qMiACTFPXUhxaxYGh7iq+YUbxVIamsywjeVFf7rBQAAAA9u36oKwHj7/MsltG8Qye59ESjaQ==</CustomCxString>
    <Server>tpratleyw7/TW</Server>
    <UserName>tc_col_own</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAFd2CtC0ewkCGSAJ5Lejs3AAAAAACAAAAAAADZgAAwAAAABAAAACVPA0Z4Y1MzpTHrsGlstfLAAAAAASAAACgAAAAEAAAAFzUa5HU5d0eSPn5/54hJ0kQAAAAlO7BV+Ui+KFfprj2/oTOihQAAABFrErgxNimIP7ObJv3sNWJKraTXg==</Password>
    <DisplayName>tc_col</DisplayName>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>true</StripUnderscores>
      <QuietenAllCaps>true</QuietenAllCaps>
      <ConnectAs>Default</ConnectAs>
      <UseOciMode>true</UseOciMode>
    </DriverData>
  </Connection>
</Query>

var weights =
from container in Containers
select container.Weight ?? -10M;

weights.Count().Dump();
weights.Sum().Dump();
weights.Average().Dump();
weights.Min().Dump();
weights.Max().Dump();


//new Func<IEnumerable<decimal>, decimal>[]
//{Enumerable.Sum, Enumerable.Average, Enumerable.Min, Enumerable.Max}
//.Select(f => f(weights))
//.Dump();
//
//// error: Enumerable.Count has a different signature, it returns an int

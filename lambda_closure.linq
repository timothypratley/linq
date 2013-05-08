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

Enumerable.Select(
	new [] {1, 2, 3, 4},
	x => x + 1)
.Dump();



int a = 3;
Func<int, int> f = x => x + a;

f(2).Dump();
	
// what will happen?
a = 10;
f(2).Dump();



// just a variable
Func<int, int> g;

// just a block scope
{
	int b = 3;
	g = x => x + b;
}

g(2).Dump();
//b.Dump();	// error: out of scope


// two variable declarations
Func<int, int> addc;
Action incc;

// block scope
{
	int c = 3;
	addc = x => x + c;
	incc = () => ++c;
}

addc(2).Dump();
incc().Dump();
addc(2).Dump();

// c is out of scope, but it is still changing!


(from c in Container
where c.ContainerNo == "CBHU1234567"
select c.Weight);

// Is closing over the string CBHU1234567, (we could have closed over a variable too)
// Integrated queries are very obvious and expressive because you don't need to make classes of comparators and so forth.


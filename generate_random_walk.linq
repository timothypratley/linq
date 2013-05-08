<Query Kind="Program">
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
  <Reference>&lt;ProgramFilesX86&gt;\Reference Assemblies\Microsoft\FSharp\3.0\Runtime\.NETPortable\FSharp.Core.dll</Reference>
  <Namespace>Microsoft.FSharp</Namespace>
  <Namespace>Microsoft.FSharp.Collections</Namespace>
</Query>

public static IEnumerable<T> Generate<T>(T current, Func<T,T> step)
{
   while (true)
   {
       yield return current;
       current = step(current);
   }
}

// Generate(x, f) => [x, f(x), f(f(x)), f(f(f(x))), ...]



void Main()
{
	// Doubling (exponential growth)
	Generate(
		2,
		x => x * 2)
	.Take(5)
	.Dump();
	
		
	// Fib
//	Generate(
//		Tuple.Create(0, 1),
//		t => Tuple.Create(t.Item2, t.Item1 + t.Item2))
//	.Select(t => t.Item1)
//	.Take(10)
//	.Dump();
//

// see RandomNormal below
	// Test our distribution
//	Generate(
//		RandomNormal(),
//		x => RandomNormal())
//	.Take(10000)
//	.GroupBy(n => Math.Round(n))
//	.ToDictionary(g => g.Key, g => g.Count())
//	.OrderBy(kvp => kvp.Key)
//	.Dump();



	// Random walk
//	Generate(
//		1500.0,
//		x => x + x * RandomNormal() * 0.05)
//	.Take(300)
//	.Zip(Enumerable.Range(0, 300), Tuple.Create)
//	.Dump();
}


Random r = new Random();
double RandomNormal() {
	// Normal distribution
	return Generate(
		r.NextDouble(),
		x => r.NextDouble())
	.Take(100)
	.Sum()
	- 49.5;
}

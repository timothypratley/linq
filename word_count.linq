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
  <Namespace>Microsoft.FSharp.Collections</Namespace>
  <Namespace>Microsoft.FSharp.Core</Namespace>
</Query>

void Main()
{
	var text = "the quick brown fox jumped over the quick brown quick chicken quick";
	var words = Regex.Split(text, @"\W+");
	words.Dump();
	
	// how can we count the occurance of each word?







	
	// I <3 dictionaries
	
//	var dict = new Dictionary<string, int>();
//	foreach(var word in words) {
//		int count;
//		if (dict.TryGetValue(word, out count)) {
//			dict[word] = count + 1;
//		} else {
//			dict[word] = 1;
//		}
//	}
//	dict.Dump();







//	(from word in words
//	group word by word into g
//	select g)
//	.Dump();

//	.ToDictionary(g => g.Key, g => g.Count())
//	.Dump();




//	// reviewing the meaning of Aggregate
//	new [] {1,1,1,1}
//	.Aggregate(10, (answer, item) => answer + item)
//	.Dump();



//	words.Aggregate(
//		new Dictionary<string, int>(),
//		(dd, word) => dd[word]++);


//	words.Aggregate(
//		new Dictionary<string, int>(),
//		(dict, word) => {
//			int count;
//			if (dict.TryGetValue(word, out count)) {
//				dict[word]++;
//			} else {
//				dict[word] = 1;
//			}
//			return dict;})
//		.Dump();

	// Dictionary syntax detracts from the meaning we wanted to express.
	// Just the same as the loop version.





//	words.Aggregate(
//		new Dictionary<string, int>(),
//		(dict, word) => Update(dict, word, x => x + 1, 0))
//	.Dump();

// Update is useful in many situations beside word counting,
// if you use Dictionaries a lot



//	words.Aggregate(
//		MapModule.Empty<string, int>(),
//		(dict, word) => Update(dict, word, x => x + 1, 0))
//	.Dump();

}


Dictionary<TKey, TValue> Update<TKey, TValue>
(Dictionary<TKey, TValue> dict, TKey key, Func<TValue, TValue> function, TValue whenNull) {
	TValue value;
	if (dict.TryGetValue(key, out value)) {
		dict[key] = function(value);
	} else {
		dict[key] = function(whenNull);
	}
	return dict;
}
// Update(dictionary, key, function, whenNull) => dictionary






FSharpMap<TKey, TValue> Update<TKey, TValue>
(FSharpMap<TKey,TValue> dictionary, TKey key, Func<TValue, TValue> function, TValue whenNull) {
	var option = dictionary.TryFind(key);
	var curr = option == FSharpOption<TValue>.None ? whenNull : option.Value;
	var next = function(curr);
    return dictionary.Add(key, next);
}
// Update(dictionary, key, function, whenNull) => new dictionary
// exactly the same form

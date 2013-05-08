<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
  </Connection>
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
// as an infinite lazy sequence


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

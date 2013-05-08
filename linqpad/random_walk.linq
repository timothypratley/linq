<Query Kind="Program" />

public static IEnumerable<T> Generate<T>(T current, Func<T,T> step)
{
   while (true)
   {
       yield return current;
       current = step(current);
   }
}

// Generate(x, f) => x, f(x), f(f(x)), f(f(f(x))), ...
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


	// Add random numbers together
	Random r = new Random();
	Func<double> RandomNormal = () =>
		Generate(
			r.NextDouble(),
			x => r.NextDouble())
		.Take(100)
		.Sum()
		- 49.5;
		
	//RandomNormal().Dump();

	// Check the distribution by generating 10000 numbers
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




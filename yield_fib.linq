<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
  </Connection>
</Query>

// Fibonacci number
IEnumerable<int> Fibs() {
	int a = 0;
	yield return a;
	int b = 1;
	yield return b;

	while (true) {
		int c = a + b;
		yield return c;
		a = b;
		b = c;
	}
}


void Main()
{
	Fibs().Take(10)


	// index the Fibonacci numbers so we can plot them
	.Zip(Enumerable.Range(1, 10), Tuple.Create)
	.Dump();
}


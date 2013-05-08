<Query Kind="Statements" />

// just a variable
Func<int, int> g;

// just a block scope
{
	int b = 3;
	g = x => x + b;
}

g(2).Dump();
//b.Dump();	// error: out of scope



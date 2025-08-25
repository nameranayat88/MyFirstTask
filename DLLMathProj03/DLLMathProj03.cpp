
#include "pch.h"

extern "C" __declspec(dllexport) int Divi(int m, int n)
{
	if (n == 0) return 0;
	return m / n ;

}
#include "pch.h"
#include <cwchar>

extern "C" __declspec(dllexport) void MathFunc(
	const wchar_t* num01, const wchar_t* num02,
	wchar_t* outBuf, int outLen)
{
	if (!outBuf || outLen <= 0) return;

	wcsncpy_s(outBuf, outLen, num01, _TRUNCATE);
	wcsncat_s(outBuf, outLen, num02, _TRUNCATE);
}

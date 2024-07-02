#!/usr/bin/perl

use strict;
use warnings;

my @enum;
my @args;

open my $enumFH, "<", "enum.txt" or die;
open my $argsFH, "<", "tmp.txt" or die;

my $max = 0;
while (<$enumFH>) {
	my $enumStr = $_;
	my $argsStr = <$argsFH>;

	chomp $enumStr;
	chomp $argsStr;
	chop $argsStr;

	$enumStr =~ s/,.*//;

	my $out1 = "Checks[(int)Check.Name.$enumStr]";
	my $out2 = " = new Check($argsStr);\n";
	my $padding = "";

	while ((length($out1) + length($out2) + length($padding)) < (92)) {
		$padding .= " ";
	}

	print $out1.$padding.$out2;
}

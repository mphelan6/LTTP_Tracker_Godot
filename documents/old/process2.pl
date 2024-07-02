#!/usr/bin/perl

use strict;
use warnings;

open my $enumFH, "<", "ow.txt" or die;

my @checks;

while (<$enumFH>) {
	if (m/"(.*)": (.*),/) {
		my $name = $1;
		my $addr = hex($2);
		$addr = $addr + 0x280;
		$addr = sprintf("%X", $addr);

		$name = uc($name);
		$name =~ s/'//g;
		$name =~ s/\ /_/g;

		print "Checks[(int)Check.Name.$name] = new Check($addr, 0x40);\n";
	} else {
		die;
	}
}

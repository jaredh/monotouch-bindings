BTOUCH=/Developer/MonoTouch/usr/bin/btouch
LIBUAIRSHIP=libUAirship-5.0.3.a
all: UrbanAirship.dll

#Please do not remove libUAirship version check
$(LIBUAIRSHIP):
	@if test -f ../../../monotouch-bindings-externals/UrbanAirShip/$(LIBUAIRSHIP); then \
		cp ../../../monotouch-bindings-externals/UrbanAirShip/$(LIBUAIRSHIP) .; \
	else \
		echo "Please download $(LIBUAIRSHIP) from http://urbanairship.com"; \
	fi

UrbanAirship.dll: Makefile AssemblyInfo.cs common.cs enums.cs $(LIBUAIRSHIP)
	$(BTOUCH) -e common.cs AssemblyInfo.cs enums.cs --out=$@ --link-with=$(LIBUAIRSHIP),$(LIBUAIRSHIP)

clean:
	-rm -rf *.a *.dll

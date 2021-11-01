CC     = gcc
WINDRES= windres
RM     = rm -f
OBJS   = main.o \
         AppResource.res

LIBS   =
CFLAGS =

.PHONY: dashboard\ designer.exe clean clean-after

all: dashboard\ designer.exe

clean:
	$(RM) $(OBJS) dashboard\ designer.exe

clean-after:
	$(RM) $(OBJS)

dashboard\ designer.exe: $(OBJS)
	$(CC) -Wall -s -o '$@' $(OBJS) $(LIBS)

main.o: main.c
	$(CC) -Wall -s -c $< -o $@ $(CFLAGS)

AppResource.res: AppResource.rc
	$(WINDRES) -i AppResource.rc -J rc -o AppResource.res -O coff


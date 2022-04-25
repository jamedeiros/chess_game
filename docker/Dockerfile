FROM mcr.microsoft.com/dotnet/core/sdk:3.1

RUN useradd -m -s $(which bash) devel

RUN mkdir /workspace && chown devel:devel /workspace

USER devel
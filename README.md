# ITSME Packages

[![Appveyor Build status][build]][build-link]

## Prerequisites

-   [Go][golang]
-   [itsme-golang][itsme-golang-library] (for now as it's not yet publicly available)

To start using this, make sure to add this repository to your [GOPATH][gopath], more information on that can be found [here][gopath].

## Project structure

To share the core ITSME OIDC logic to the multitude of generated packages, we use Go to create the logic, then create a shared C library which is the used to create binding with in all different languages out there. The core is kept shared and we expose a native, familiar interface per language. The goal is that the consumer of a language specifc package does not need to care or see that there's a different engine under the hood, as far as they know, it's all native. We can compile for different platforms as well so there's no need for any additional libraries to use this.

The project is created this way:

-   [itsme-golang][itsme-golang-library] -> dependency of the clang [`itsme.go`][clang-main] file
-   [`itsme.go`][clang-main] exposes [itsme-golang][itsme-golang-library] functionality by creating C style functions using [cgo][cgo-link]
-   [`itsme.go`][clang-main] is built as a shared library for Unix (`itsme_lib.so`) and Windows (`itsme_lib.dll`)
-   The created shared libraries are used in the language specific projects where the C library is exposed using a native bridge which is specific per language

## Developing

As each binding package is created in the language it is used for, the specific details per package can be found in those folder's `README.md`. Scripts to run this on Windows (using PowerShell) and Unix (using plain bash scripts) are available in the project repositories. Be advised that for the packages to be created, you need to be able to build the C library for both Windows and Unix. A CI system will be made available to facilitate this going forward.

## Creating a package binding

To make sure you are compatible with the underlying structure, the bindings need to expose objects which can be marchalled into json which can then in turn be marchalled back to objects by the Golang C bridge. This is done to keep the interface as simple and as performant as possible.

The objects needed are the ones used in the exposed function code in our [Go library][itsme-golang-library]:

```go
type ItsmeSettings struct {
	ClientID             string `json:"client_id"`
	RedirectURI          string `json:"redirect_uri"`
	SigningCertificateID string `json:"signing_certificate_id"`
	SigningCert          string `json:"signing_cert"`
	EncryptionCert       string `json:"encryption_cert"`
}

//URLConfiguration defines the config needed to construct the OIDC url
type URLConfiguration struct {
	Scopes      []string `json:"scopes"`
	ServiceCode string   `json:"service_code"`
	RequestURI  string   `json:"request_uri"`
}
```

Have a look at one of the current bindings to see how this works.

## Authors

-   [Jan De Dobbeleer][jdd] (Initial work)
-   [Roeland Matthijssens][enermis]

[build]: https://ci.appveyor.com/api/projects/status/github/itsme-sdk/itsme-packages?branch=master&svg=true
[build-link]: https://ci.appveyor.com/project/itsme-sdk/itsme-packages
[golang]: https://golang.org/doc/install
[itsme-golang-library]: https://github.com/itsme-sdk/itsme-golang
[gopath]: https://github.com/golang/go/wiki/GOPATH
[clang-main]: https://github.com/itsme-sdk/itsme-golang/blob/master/lib/itsme.go
[cgo-link]: https://golang.org/cmd/cgo/
[jdd]: https://gist.github.com/JanDeDobbeleer
[enermis]: https://github.com/RoelandMatthijssens

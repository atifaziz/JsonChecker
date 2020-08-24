# JSON Checker

JSON Checker is a console-based tool implemented as a [Pushdown Automaton]
that very quickly determines if a JSON text is syntactically correct. It could
be used to filter inputs to a system, or to verify that the outputs of a
system are syntactically correct.

JSON Checker is a straight C# port of [JSON_checker] written in C.

  [Pushdown Automaton]: http://en.wikipedia.org/wiki/Pushdown_automaton
  [JSON_checker]: http://www.json.org/JSON_checker/


## Usage

JSON Checker reads the JSON text source from the standard input and emits a
message on the standard error as soon as it encounters a syntax error. JSON
Checker does not attempt to recover errors so it halts further processing once
a syntax error has been detected. To check a file, use JSON Checker on the
command line as follows (replacing `FILE` with the actual file path):

    $ jsonchk < FILE


## Requirements

JSON Checker requires [.NET Core 3.1][dotnet-3.1] to run and supports the same
set of operating systems as the runtime.

  [dotnet-3.1]: https://dotnet.microsoft.com/download/dotnet-core/3.1


## License

JSON Checker is distributed under the OSI-approved and liberal [New BSD
License][newbsd]:

> Copyright (c) 2007, Atif Aziz. All rights reserved.
>
> Redistribution and use in source and binary forms, with or without
> modification, are permitted provided that the following conditions are met:
>
> * Redistributions of source code must retain the above copyright notice,
> this list of conditions and the following disclaimer.
> * Redistributions in binary form must reproduce the above copyright notice,
> this list of conditions and the following disclaimer in the documentation
> and/or other materials provided with the distribution.
> * Neither the name of the author nor the names of its contributors may be
> used to endorse or promote products derived from this software without
> specific prior written permission.
>
> THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
> AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
> IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
> ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
> LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
> CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
> SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
> INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
> CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
> ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
> POSSIBILITY OF SUCH DAMAGE.

  [newbsd]: https://opensource.org/licenses/BSD-3-Clause

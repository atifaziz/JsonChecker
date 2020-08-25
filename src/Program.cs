#region Copyright (c) 2007 Atif Aziz. All rights reserved.
//
// This library is free software; you can redistribute it and/or modify it
// under the terms of the New BSD License, a copy of which should have
// been delivered along with this distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
#endregion

using System;
using System.Diagnostics;
using System.IO;

static class Program
{
    static int Main(string[] args)
    {
        try
        {
            var (close, reader)
                = args.Length > 0
                ? (true, File.OpenText(args[0]))
                : (false, Console.In);

            try
            {
                var checker = new JsonChecker(20);
                for (var ch = reader.Read(); ch != -1; ch = reader.Read())
                    checker.Check(ch);
                checker.FinalCheck();
            }
            finally
            {
                if (close)
                    reader.Close();
            }

            return 0;
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.GetBaseException().Message);
            Trace.WriteLine(e.ToString());
            return 1;
        }
    }
}

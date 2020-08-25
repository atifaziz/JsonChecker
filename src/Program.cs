#region License, Terms and Author(s)
//
// JSON Checker
// Copyright (c) 2007 Atif Aziz. All rights reserved.
//
//  Author(s):
//
//      Atif Aziz, http://www.raboof.com
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

namespace JsonCheckerTool
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    #endregion

    static class Program
    {
        static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    ValidateJsonText(Console.In);
                }
                else
                {
                    using (TextReader reader = File.OpenText(args[0]))
                        ValidateJsonText(reader);
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

        public static void ValidateJsonText(TextReader reader)
        {
            ValidateJsonText(ReadChars(reader));
        }

        public static void ValidateJsonText(IEnumerable<char> chars)
        {
            JsonChecker checker = new JsonChecker(20);
            foreach (char ch in chars)
                checker.Check(ch);
            checker.FinalCheck();
        }

        static IEnumerable<char> ReadChars(TextReader reader)
        {
            int ch = reader.Read();
            while (ch != -1)
            {
                yield return (char)ch;
                ch = reader.Read();
            }
        }
    }
}

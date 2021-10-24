﻿using System;
using System.Collections;
using System.IO;
using System.Security;
using System.Security.Principal;
using Microsoft.Win32;

namespace GetLucky
{
    public static class Index
    {
        public enum KeyIndexWin : int
        {
            KEY_START_INDEX = 0x34,
            KEY_END_INDEX = KEY_START_INDEX + 0xF,
            DECODE_LENGTH = 0x1D,
            DECODE_STRING = 0xF
        }

        public enum Type
        {
            Sequence = 0x30, // 48
            Integer = 0x02,
            BitString = 0x03,
            OctetString = 0x04,
            Null = 0x05,
            ObjectIdentifier = 0x06
        }
    }
    class WinKey
    {
        public static string GetDecodeKey(byte[] DigitalProductID)
        {
            int DigitMapIndex = 0;

            var HexPid = new ArrayList();
            for (int i = (int)Index.KeyIndexWin.KEY_START_INDEX; i <= (int)Index.KeyIndexWin.KEY_END_INDEX; i++)
            {
                HexPid.Add(DigitalProductID[i]);
            }
            char[] DecodedChars = new char[(int)Index.KeyIndexWin.DECODE_LENGTH];
            for (int i = (int)Index.KeyIndexWin.DECODE_LENGTH - 1; i >= 0; i--)
            {
                if ((i + 1) % 0x6 != 0)
                {
                    for (int j = (int)Index.KeyIndexWin.DECODE_STRING - 1; j >= 0; j--)
                    {
                        HexPid[j] = (byte)(((DigitMapIndex << 0b1000) | (byte)HexPid[j]) / 0x18);
                        DigitMapIndex = ((DigitMapIndex << 0b1000) | (byte)HexPid[j]) % 0x18;

                        char[] Digits = new[] { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'M', 'P', 'Q', 'R', 'T', 'V', 'W', 'X', 'Y', '2', '3', '4', '6', '7', '8', '9', };

                        DecodedChars[i] = Digits[DigitMapIndex];
                    }
                }
                else
                {
                    DecodedChars[i] = '-';
                }
            }
            return new string(DecodedChars);
        }

        public static string GetDecodeKeyWin8AndUp(byte[] DigitalProductId)
        {
            string Result_Key = string.Empty;
            int Current = 0;
            DigitalProductId[0x42] = (byte)((DigitalProductId[0x42] & 0xf7) | (((byte)((DigitalProductId[0x42] / 0x6) & 0x1) & 0x2) * 0x4));
            for (int i = 0x18; i >= 0; i--)
            {
                for (int j = 0xE; j >= 0; j--)
                {
                    Current *= 0x100;
                    Current = DigitalProductId[j + 0x34] + Current;
                    DigitalProductId[j + 0x34] = (byte)(Current / 0x18);
                    Current %= 24;
                }
            }

            Result_Key = $"{"BCDFGHJKMPQRTVWXY2346789"[Current]}{Result_Key}";
            Result_Key = $"{Result_Key.Substring(1, 0)}N{Result_Key.Substring(0 + 1, Result_Key.Length - (0 + 1))}";

            for (int i = 5; i < Result_Key.Length; i += 0x6)
            {
                Result_Key = Result_Key.Insert(i, "-");
            }

            return Result_Key;
        }

        public static string GetWindowsKey(string Path, string GetID)
        {

            string result = string.Empty;
            RegistryHive registryHive = RunChecker.IsAdmin ? RegistryHive.LocalMachine : RegistryHive.CurrentUser;
            RegistryView registryView = RunChecker.IsWin64 ? RegistryView.Registry64 : RegistryView.Registry32;
            try
            {
                using (var hklmHive = RegistryKey.OpenBaseKey(registryHive, registryView))
                using (RegistryKey Key = hklmHive.OpenSubKey(Path, RunChecker.IsWin64))
                {
                    result = (Environment.OSVersion.Version.Major != 0x6 ||
                              Environment.OSVersion.Version.Minor < 0x2) &&
                             Environment.OSVersion.Version.Major <= 0x6 ?
                   GetDecodeKey((byte[])Key.GetValue(GetID)) : GetDecodeKeyWin8AndUp((byte[])Key.GetValue(GetID));
                }
            
            }
            catch (Exception) { return "Unknown WinKey"; }

            return result;

        }
    }
    public static class RunChecker
    {
        public static bool IsAdmin => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        public static bool IsWin64 => Environment.Is64BitOperatingSystem ? true : false;
    }
}

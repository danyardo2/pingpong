﻿using System.Net.Sockets;
using Common.IO.Abstractions;

namespace BLL
{
    public class UserHandler
    {
        private UserInputCatcher<object> _inputCatcher;
        private IOutput<string> _output;

        public UserHandler(UserInputCatcher<object> inputCatcher, IOutput<string> output)
        {
            _inputCatcher = inputCatcher;
            _output = output;
        }

        public async void HandleUser(Socket handler) 
        {
            _output.Output("New user logged.");

            string? data = null;
            byte[]? bytes = null;

            try
            {
                await Task.Run(() =>
                {
                    while (true)
                    {
                        _inputCatcher.GetUserInput(handler);
                    }
                });
            }
            catch (SocketException e)
            {
                _output.Output("User logged out.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

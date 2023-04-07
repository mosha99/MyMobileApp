using DAL.Repository;
using FluentValidation;
using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommandANDQuery.Financial.Commands;

public sealed record AddPersonCommand(string Name) : IRequest<CustomResponse>;


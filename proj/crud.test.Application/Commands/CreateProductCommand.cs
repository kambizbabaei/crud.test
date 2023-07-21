﻿using Test.abstraction.Commands;

namespace crud.test.Application.Commands;

public record CreateProductCommand(bool IsAvailable, string ManufactureEmail, string ManufacturePhone,
    DateTime ProduceDate, string Name) : ICommand;
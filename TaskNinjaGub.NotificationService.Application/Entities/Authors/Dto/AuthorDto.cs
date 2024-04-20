﻿using TaskNinjaGub.NotificationService.Application.Entities.Authors.Enums;

namespace TaskNinjaGub.NotificationService.Application.Entities.Authors.Dto;

public class AuthorDto
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public LocalizationType LocalizationType { get; set; }
}
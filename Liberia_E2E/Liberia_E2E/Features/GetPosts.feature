﻿Feature: GetPosts
	Test GET posts operation with Resharp


Scenario: Verify author of the post 1
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "1"
	Then I should see the "author" name as "Karthik KK"
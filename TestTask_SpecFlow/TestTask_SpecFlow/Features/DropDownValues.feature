Feature: DropDownValues
	Testing DropDown list options

@DropDownValues
Scenario: Count DropDown Options
	Given dropdown page is opened
	And dropdown element was found
	Then count dropdown elements

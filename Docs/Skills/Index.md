# Skills for nsquared agents

An agent skill is a function/tool that an LLM host can call to perform a specific task, such as
reading a data source or carrying out an action. Skills are implemented by command plugins and
described with a function name, description, and JSON parameter schema.

> [Build a simple skill](Building%20a%20Simple%20Skill.md)

> [Skill API reference](IAgentSkill.md)

Skills are supplied by commands implementing `IAgentSkillProvider`. An LLM command that accepts
skills implements `IAgentSkillHost`; the application passes the provider's skills to the host when
commands are loaded. You do not need to maintain a central command-name list in the skill.

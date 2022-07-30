from config import IMG_HELP, COLOR_HELP
from typing import Optional, Set
from nextcord import Embed
from nextcord.ext import commands


class HelpCommand(commands.MinimalHelpCommand):
    def get_command_signature(self, command):
        return (
            f"{self.context.clean_prefix}{command.qualified_name} {command.signature}"
        )

    async def _help_embed(
        self,
        title: str,
        mapping: Optional[dict] = None,
        description: Optional[str] = None,
        command_set: Optional[Set[commands.Command]] = None,
    ) -> Embed:

        embed: Embed = Embed(title=title, color=COLOR_HELP)
        embed.set_thumbnail(url=IMG_HELP)

        if description:
            embed.description = description

        if command_set:
            filtered = await self.filter_commands(command_set, sort=True)

            for command in filtered:
                embed.add_field(
                    name=self.get_command_signature(command),
                    value=command.help,
                    inline=False,
                )

        elif mapping:
            for cog, command_set in mapping.items():
                filtered = await self.filter_commands(command_set, sort=True)

                if not filtered:
                    continue

                name = cog.qualified_name if cog else "No category"
                cmd_list = "\n".join(
                    f"{self.context.clean_prefix}[{cmd.name}](https://archleaders.github.io/botwtoolsbot/commands/#{cmd.name})\u2009"
                    for cmd in filtered
                )
                value = (
                    f"{cog.description}\n{cmd_list}"
                    if cog and cog.description
                    else cmd_list
                )
                embed.add_field(name=name, value=value, inline=False)

        return embed

    async def send_bot_help(self, mapping: dict):
        await self.get_destination().send(
            embed=await self._help_embed(
                title="Commands",
                mapping=mapping,
                description=self.context.bot.description,
            )
        )

    async def send_command_help(self, command: commands.Command):
        await self.get_destination().send(
            embed=await self._help_embed(
                title=command.qualified_name,
                description=command.help,
                command_set=commands.commands
                if isinstance(command, commands.Group)
                else None,
            )
        )

    async def send_cog_help(self, cog: commands.Cog):
        await self.get_destination().send(
            embed=await self._help_embed(
                title=cog.qualified_name,
                description=cog.description,
                command_set=cog.get_commands(),
            )
        )

    send_group_help = send_command_help


class HelpCog(commands.Cog, name="Bot"):
    """Provides information on the availible commands."""

    def __init__(self, bot):
        self._original_help_command = bot.help_command
        bot.help_command = HelpCommand()
        bot.help_command.cog = self

    def cog_unload(self):
        self.bot.help_command = self._original_help_command


def setup(bot: commands.Bot):
    bot.add_cog(HelpCog(bot))

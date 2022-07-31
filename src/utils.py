import json

from nextcord import Member
from config import SRC, REMOTE, BOT, SERVER_ID
from pathlib import Path


def save_json(database: str, obj) -> None:
    """Serializes the defined JSON data file"""

    Path(f"{SRC}/data/{database}.json").write_text(json.dumps(obj, indent=4))


def load_json(database: str):
    """Deserializes the defined JSON data file and returns the object"""

    return json.loads(Path(f"{SRC}/data/{database}.json").read_text())


def load_cogs():
    """Loads every file in the defined folder"""

    for file in Path(f"{SRC}\\src\\cogs").glob("**/*.py"):

        if file.is_file() and "_view.py" not in file.name:
            # format name
            if REMOTE:
                name = (
                    file.as_posix()
                    .replace(".py", "")
                    .replace("/app/heroku/src/cogs/", "")
                    .replace("/", ".")
                )
            else:
                name = (
                    file.as_posix()
                    .replace(".py", "")
                    .replace("/", ".")
                    .replace("src.cogs.", "")
                )

            try:
                # load cog
                BOT.load_extension(f"cogs.{name}")

                # log success
                print(f"Loaded COG: {name}")
            except Exception as ex:
                print(ex)
                pass


def check(user: Member, roles: list) -> bool:
    return any(
        p_role in user.roles
        for p_role in [BOT.get_guild(SERVER_ID).get_role(role) for role in roles]
    )

import json

from config import SRC, REMOTE, BOT
from pathlib import Path


def update_database(database: str, obj) -> None:
    """Serializes the defined JSON data file"""

    Path(f"{SRC}/data/{database}.jsonc").write_text(json.dumps(obj, indent=4))


def load_database(database: str):
    """Deserializes the defined JSON data file and returns the object"""

    return json.loads(Path(f"{SRC}/data/{database}.jsonc").read_text())


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

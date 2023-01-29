import unittest

from unittest.mock import Mock

from Hero import Hero


class MyTestCase(unittest.TestCase):

    @staticmethod
    def test_hit():
        hero = Hero()
        resulting_value = hero.hit()
        assert (5 <= resulting_value <= 7)

    @staticmethod
    def test_eat_regeneration():
        hero = Hero()
        food = Mock()
        food.type = "regeneration"
        food.regeneration = 4
        food.coef = 0

        # Соблюдай структуру юнит теста
        resulting_value = hero.eat(food)

        assert (resulting_value == 24)

    @staticmethod
    def test_eat_upgrade():
        hero = Hero()
        food = Mock()
        food.type = "upgrade"
        food.regeneration = 5
        food.coef = 1.3
        resulting_value = hero.eat(food)
        assert (resulting_value == 26)

    @staticmethod
    def test_is_died_false():
        hero = Hero()
        hero.set_health(5)
        resulting_value = hero.is_died()
        assert (not resulting_value)

    @staticmethod
    def test_is_died_true():
        hero = Hero()
        hero.set_health(-1)
        resulting_value = hero.is_died()
        assert resulting_value

    @staticmethod
    def test_is_died_health_equal_null():
        hero = Hero()
        food = Mock()
        food.type = "upgrade"
        food.regeneration = 5
        food.coef = 0
        resulting_value = hero.eat(food)

        assert (resulting_value == 0)
        resulting_value = hero.is_died()
        assert resulting_value

    # Добавить тест с upgrade с кофф = 0 -> персонаж должен умереть

    @staticmethod
    def test_equip_weapon():
        hero = Hero()
        weapon = Mock()
        weapon.type = "weapon"
        weapon.attack = 3
        weapon.magic = 2
        weapon.luck = 1

        resulting_value = hero.equip_item(weapon).__dict__
        expected_value = Hero(20, 8, 3, 3, 1, 4, "Hero", 0, 0, ["weapon"]).get_info().__dict__
        assert (resulting_value == expected_value)

    @staticmethod
    def test_equip_bow():
        hero = Hero()
        bow = Mock()
        bow.type = "bow"
        bow.ranged = 3
        bow.luck = 1
        assert hero.equip_item(bow).__dict__ == Hero(20, 5, 3, 6, 1, 2, "Hero", 0, 0, ["bow"]).get_info().__dict__

    @staticmethod
    def test_equip_armor():
        hero = Hero()
        armor = Mock()
        armor.type = "armor"
        armor.health = 7
        armor.defence = 8
        armor.luck = 2
        resulting_value = hero.equip_item(armor).__dict__
        expected_value = Hero(27, 5, 4, 3, 9, 2, "Hero", 0, 0, ["armor"]).get_info().__dict__
        assert (resulting_value == expected_value)

    @staticmethod
    def test_unequip_weapon():
        hero = Hero()
        weapon = Mock()
        weapon.type = "weapon"
        weapon.attack = 3
        weapon.magic = 2
        weapon.luck = 1
        hero.equip_item(weapon)
        resulting_value = hero.unequip_item(weapon).__dict__
        expected_value = Hero(20, 5, 2, 3, 1, 2, "Hero", 0, 0, []).get_info().__dict__
        assert (resulting_value == expected_value)

    @staticmethod
    def test_unequip_bow():
        hero = Hero()
        bow = Mock()
        bow.type = "bow"
        bow.ranged = 3
        bow.luck = 1
        hero.equip_item(bow)
        resulting_value = hero.unequip_item(bow).__dict__
        expected_value = Hero(20, 5, 2, 3, 1, 2, "Hero", 0, 0, []).get_info().__dict__
        assert (resulting_value == expected_value)

    @staticmethod
    def test_unequip_armor():
        hero = Hero()
        armor = Mock()
        armor.type = "armor"
        armor.health = 7
        armor.defence = 8
        armor.luck = 2
        hero.equip_item(armor)
        resulting_value = hero.unequip_item(armor).__dict__
        expected_value = Hero(20, 5, 2, 3, 1, 2, "Hero", 0, 0, []).get_info().__dict__
        assert (resulting_value == expected_value)

    # Добавить методы с несколькими ипами на equip и unequip

    @staticmethod
    def test_equip_armor_and_weapon():
        hero = Hero()

        armor = Mock()
        armor.type = "armor"
        armor.health = 7
        armor.defence = 8
        armor.luck = 2
        hero.equip_item(armor)

        weapon = Mock()
        weapon.type = "weapon"
        weapon.attack = 3
        weapon.magic = 2
        weapon.luck = 1

        resulting_value = hero.equip_item(weapon).__dict__
        expected_value = Hero(27, 8, 5, 3, 9, 4, "Hero", 0, 0, ["armor", "weapon"]).get_info().__dict__
        assert (resulting_value == expected_value)

    @staticmethod
    def test_unequip_armor_and_weapon():
        hero = Hero()

        armor = Mock()
        armor.type = "armor"
        armor.health = 7
        armor.defence = 8
        armor.luck = 2
        hero.equip_item(armor)

        weapon = Mock()
        weapon.type = "weapon"
        weapon.attack = 3
        weapon.magic = 2
        weapon.luck = 1
        hero.equip_item(weapon)

        resulting_value = hero.unequip_item(armor).__dict__
        expected_value = Hero(20, 8, 3, 3, 1, 4, "Hero", 0, 0, ["weapon"]).get_info().__dict__
        assert (resulting_value == expected_value)


if __name__ == '__main__':
    unittest.main()

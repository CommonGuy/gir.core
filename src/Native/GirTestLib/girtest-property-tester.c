#include "girtest-property-tester.h"
#include "girtest-typed-record-tester.h"

/**
 * GirTestPropertyTester:
 *
 * Contains properties to test bindings.
 */

typedef enum
{
    PROP_STRING_VALUE = 1,
    PROP_PROPERTY_TESTER = 2,
    PROP_TYPED_RECORD_VALUE = 3,
    N_PROPERTIES
} PropertyTesterProperty;

struct _GirTestPropertyTester
{
    GObject parent_instance;

    gchar *string_value;
    gchar *property_tester;
    GirTestTypedRecordTester* record;
};

G_DEFINE_TYPE(GirTestPropertyTester, girtest_property_tester, G_TYPE_OBJECT)

static GParamSpec *properties[N_PROPERTIES];


static void
girtest_property_tester_get_property (GObject    *object,
                                    guint       prop_id,
                                    GValue     *value,
                                    GParamSpec *pspec)
{
    GirTestPropertyTester *self = GIRTEST_PROPERTY_TESTER (object);

    switch (prop_id)
    {
    case PROP_STRING_VALUE:
        g_value_set_string (value, self->string_value);
        break;
    case PROP_PROPERTY_TESTER:
        g_value_set_string (value, self->property_tester);
        break;
    case PROP_TYPED_RECORD_VALUE:
        g_value_set_boxed (value, self->record);
        break;
    default:
        G_OBJECT_WARN_INVALID_PROPERTY_ID (object, prop_id, pspec);
    }
}

static void
girtest_property_tester_set_property (GObject      *object,
                                    guint         prop_id,
                                    const GValue *value,
                                    GParamSpec   *pspec)
{
    GirTestPropertyTester *self = GIRTEST_PROPERTY_TESTER (object);

    switch (prop_id)
    {
    case PROP_STRING_VALUE:
        self->string_value = g_value_dup_string (value);
        break;
    case PROP_PROPERTY_TESTER:
        self->property_tester = g_value_dup_string (value);
        break;
    case PROP_TYPED_RECORD_VALUE:
        self->record = g_value_get_boxed (value);
        break;
    default:
        G_OBJECT_WARN_INVALID_PROPERTY_ID (object, prop_id, pspec);
    }
}

static void
girtest_property_tester_init(GirTestPropertyTester *value)
{
}

static void
girtest_property_tester_class_init(GirTestPropertyTesterClass *class)
{
    GObjectClass *object_class = G_OBJECT_CLASS (class);

    object_class->set_property = girtest_property_tester_set_property;
    object_class->get_property = girtest_property_tester_get_property;

    properties[PROP_STRING_VALUE] =
      g_param_spec_string ("string-value",
                           "String Value",
                           "A string value",
                           NULL  /* default value */,
                           G_PARAM_READWRITE);

    properties[PROP_PROPERTY_TESTER] =
      g_param_spec_string ("property-tester",
                           "Property Tester",
                           "A string value named like it's class",
                           NULL  /* default value */,
                           G_PARAM_READWRITE);

   /**
   * GirPropertyTester:record-value:
   * Contains a typed record tester
   */
    properties[PROP_TYPED_RECORD_VALUE] =
      g_param_spec_boxed ("record-value", NULL, NULL, GIRTEST_TYPE_TYPED_RECORD_TESTER, G_PARAM_READWRITE);

    g_object_class_install_properties (object_class, N_PROPERTIES, properties);
}

/**
 * girtest_property_tester_new:
 *
 * Creates a new `GirTestPropertyTester`.
 *
 * Returns: The newly created `GirTestPropertyTester`.
 */
GirTestPropertyTester*
girtest_property_tester_new (void)
{
    return g_object_new (GIRTEST_TYPE_PROPERTY_TESTER, NULL);
}